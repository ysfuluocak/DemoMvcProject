using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Utilities.Business;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;


namespace DemoMvcProject.Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        private readonly IProductService _productService;
        private readonly ICartItemService _cartItemService;

        public CartManager(ICartDal cartDal, IProductService productService, ICartItemService cartItemService)
        {
            _cartDal = cartDal;
            _productService = productService;
            _cartItemService = cartItemService;
        }

        public IDataResult<Cart> Add(Cart cart)
        {
            cart.Status = true;
            _cartDal.Add(cart);
            return new SuccessDataResult<Cart>(cart,Messages.CartAdded);
        }

        public IResult AddToCart(int ProductId)
        {
            var product = _productService.GetProductDetails(ProductId);
            var cart = GetActiveCart().Data ?? Add(new Cart()).Data;
            var existingItem = cart.CartItems.FirstOrDefault(p => p.ProductId == ProductId);
            if (existingItem is not null)
            {
                existingItem.Quantity += 1;
                existingItem.Subtotal = existingItem.Quantity * existingItem.Price;
                _cartItemService.Update(existingItem);
                return new SuccessResult(Messages.CartItemAddedForCart);
            }
            else
            {
                var newCartItem = new CartItem()
                {
                    Price = product.Data.Price,
                    ProductId = ProductId,
                    ProductName = product.Data.ProductName,
                    Quantity = 1,
                    Status = true,
                    Subtotal = product.Data.Price,
                    CartId = cart.Id
                };
                _cartItemService.Add(newCartItem);
                return new SuccessResult(Messages.CartItemAddedForCart);
            }

        }

        public IResult Delete(Cart cart)
        {
            cart.Status = false;
            _cartDal.Update(cart);
            return new SuccessResult(Messages.CartDeleted);
        }

        public IResult DeleteToCart(int ProductId)
        {
            var cart = GetActiveCart();
            var existingItem = cart.Data.CartItems.FirstOrDefault(p => p.ProductId == ProductId);
            if (existingItem is null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            if (existingItem.Quantity > 1)
            {
                existingItem.Quantity -= 1;
                existingItem.Subtotal = existingItem.Quantity * existingItem.Price;
                _cartItemService.Update(existingItem);
                return new SuccessResult(Messages.CartItemDeletedForCart);
            }
            else
            {
                existingItem.Quantity = 0;
                existingItem.Subtotal = 0;
                _cartItemService.Delete(existingItem);
                return new SuccessResult(Messages.CartItemDeletedForCart);
            }
        }

        public IDataResult<Cart> GetActiveCart()
        {
            return new SuccessDataResult<Cart>(_cartDal.GetActiveCart(),Messages.ActiveCartsListed);
        }

        public IDataResult<IEnumerable<Cart>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Cart>>(_cartDal.GetAll(),Messages.CartsListed);
        }

        public IDataResult<Cart> GetById(int id)
        {
            return new SuccessDataResult<Cart>(_cartDal.Get(c => c.Id == id),Messages.CartShown);
        }

        public IResult PlaceOrder()
        {
            var activeCart = GetActiveCart().Data;
            var result = BusinessRules.Run(IsStockAvailableForOrder(activeCart.CartItems));
            if(result != null)
            {
                return new ErrorResult(Messages.OutOfStock);
            }
            activeCart.Status = false;
            activeCart.TotalPrice = activeCart.CartItems.Sum(ci => ci.Subtotal);
            Update(activeCart);

            foreach (var item in activeCart.CartItems)
            {
                item.Status = false;
                _cartItemService.Update(item);
                _productService.UpdateProductStock(item.ProductId, item.Quantity);
            }
            return new SuccessResult(Messages.OrderCompleted);
        }

        public IResult Update(Cart cart)
        {
            _cartDal.Update(cart);
            return new SuccessResult(Messages.CartUpdated);
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
    }
}
