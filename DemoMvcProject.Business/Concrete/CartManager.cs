using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Utilities.Business;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using IResult = DemoMvcProject.Core.Utilities.Results.IResult;

namespace DemoMvcProject.Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        private readonly IProductService _productService;
        private readonly ICartItemService _cartItemService;
        private readonly ICustomerService _customerService;

        public CartManager(ICartDal cartDal, IProductService productService, ICartItemService cartItemService, ICustomerService customerService)
        {
            _cartDal = cartDal;
            _productService = productService;
            _cartItemService = cartItemService;
            _customerService = customerService;
        }

        public IDataResult<Cart> Add(Cart cart)
        {
            cart.Status = true;
            _cartDal.Add(cart);
            return new SuccessDataResult<Cart>(cart, Messages.CartAdded);
        }

        public IResult AddToCart(int userId, int productId)
        {
            var customer = GetOrCreateCustomer(userId);
            var product = _productService.GetById(productId);

            var cart = GetOrCreateCart(customer.Id);

            var existingItem = cart.CartItems.FirstOrDefault(p => p.ProductId == productId);
            if (existingItem is not null)
            {
                existingItem.Quantity += 1;
                UpdateExistingCartItem(existingItem);
            }
            else
            {
                AddNewCartItem(cart.Id, product.Data);

            }
            return new SuccessResult(Messages.CartItemAddedForCart);
        }

        public IResult Delete(Cart cart)
        {
            cart.Status = false;
            _cartDal.Update(cart);
            return new SuccessResult(Messages.CartDeleted);
        }

        public IResult Update(Cart cart)
        {
            _cartDal.Update(cart);
            return new SuccessResult(Messages.CartUpdated);
        }

        public IResult DeleteToCart(int customerId, int productId)
        {
            var cart = GetActiveCartByCustomerId(customerId);
            var existingItem = cart.Data.CartItems.FirstOrDefault(p => p.ProductId == productId);
            if (existingItem is null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            if (existingItem.Quantity > 1)
            {
                existingItem.Quantity -= 1;
                UpdateExistingCartItem(existingItem);
                //existingItem.Subtotal = existingItem.Quantity * existingItem.Price;
                //_cartItemService.Update(existingItem);
            }
            else
            {
                existingItem.Quantity = 0;
                UpdateExistingCartItem(existingItem);
                //existingItem.Subtotal = 0;
                //_cartItemService.Delete(existingItem);

            }
            return new SuccessResult(Messages.CartItemDeletedForCart);
        }

        public IResult PlaceOrder(int customerId)
        {
            var activeCart = GetActiveCartByCustomerId(customerId).Data;
            var result = BusinessRules.Run(IsStockAvailableForOrder(activeCart.CartItems), DeactivateCartForSuccessOrder(activeCart),
                UpdateCartItemsForProductStock(activeCart));
            if (result != null)
            {
                return new ErrorResult(Messages.OutOfStock);
            }
            return new SuccessResult(Messages.OrderCompleted);
        }

        public IDataResult<Cart> GetActiveCartByCustomerId(int customerId)
        {
            return new SuccessDataResult<Cart>(_cartDal.GetActiveCart(customerId), Messages.ActiveCartsListed);
        }

        public IDataResult<IEnumerable<Cart>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Cart>>(_cartDal.GetAll(), Messages.CartsListed);
        }

        public IDataResult<Cart> GetById(int id)
        {
            return new SuccessDataResult<Cart>(_cartDal.Get(c => c.Id == id), Messages.CartShown);
        }

        public IDataResult<IEnumerable<Cart>> GetCartsByCustomerId(int customerId)
        {
            return new SuccessDataResult<IEnumerable<Cart>>(_cartDal.GetAll(c => c.CustomerId == customerId), Messages.CartsListed);
        }


        private Customer GetOrCreateCustomer(int userId)
        {
            var customer = _customerService.GetByUserId(userId).Data;
            if (customer == null)
            {
                customer = new Customer() { UserId = userId };
                customer.Id = _customerService.Add(customer).Data;
            }
            return customer;
        }
        private Cart GetOrCreateCart(int customerId)
        {
            var cart = GetActiveCartByCustomerId(customerId).Data;
            if (cart == null)
            {
                cart = Add(new Cart() { CustomerId = customerId }).Data;
            }
            return cart;
        }




        private IResult DeactivateCartForSuccessOrder(Cart activeCart)
        {
            activeCart.Status = false;
            activeCart.TotalPrice = activeCart.CartItems.Sum(ci => ci.Subtotal);
            Update(activeCart);
            return new SuccessResult();
        }

        private IResult UpdateCartItemsForProductStock(Cart activeCart)
        {
            foreach (var item in activeCart.CartItems)
            {
                item.Status = false;
                _cartItemService.Update(item);
                _productService.UpdateProductStock(item.ProductId, item.Quantity);
            }
            return new SuccessResult();
        }

        private IResult IsStockAvailableForOrder(ICollection<CartItem> items)
        {
            foreach (var item in items)
            {
                var product = _productService.GetById(item.ProductId);
                if (product.Data == null || product.Data.Stock < item.Quantity)
                {
                    return new ErrorResult(Messages.OutOfStock);
                }
            }
            return new SuccessResult();
        }

        private IResult UpdateExistingCartItem(CartItem existingItem)
        {
            //existingItem.Quantity += 1;
            existingItem.Subtotal = existingItem.Quantity * existingItem.Price;
            _cartItemService.Update(existingItem);
            return new SuccessResult();

        }

        private IResult AddNewCartItem(int cartId, Product product)
        {
            var newCartItem = new CartItem()
            {
                Price = product.Price,
                ProductId = product.Id,
                ProductName = product.ProductName,
                Quantity = 1,
                Status = true,
                Subtotal = product.Price,
                CartId = cartId
            };
            var result = _cartItemService.Add(newCartItem);
            if (result.Success)
            {
                return new SuccessResult(result.Message);
            }
            return new ErrorResult(result.Message);
        }
    }
}
