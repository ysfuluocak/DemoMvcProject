using DemoMvcProject.Business.Abstract;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Cart Add(Cart cart)
        {
            cart.Status = true;
            _cartDal.Add(cart);
            return cart;
        }

        public void AddToCart(int ProductId)
        {
            var product = _productService.GetProductDetails(ProductId);
            var cart = GetActiveCart() ?? Add(new Cart());
            var existingItem = cart.CartItems.FirstOrDefault(p => p.ProductId == ProductId);
            if (existingItem is not null)
            {
                existingItem.Quantity += 1;
                existingItem.Subtotal = existingItem.Quantity * existingItem.Price;
                _cartItemService.Update(existingItem);
            }
            else
            {
                var newCartItem = new CartItem()
                {
                    Price = product.Price,
                    ProductId = ProductId,
                    ProductName = product.ProductName,
                    Quantity = 1,
                    Status = true,
                    Subtotal = product.Price,
                    CartId = cart.Id
                };

                cart.CartItems.Add(newCartItem);
                _cartItemService.Add(newCartItem);
            }

        }

        public void Delete(Cart cart)
        {
            cart.Status = false;
            _cartDal.Update(cart);
        }

        public Cart GetActiveCart()
        {
            return _cartDal.GetActiveCart();
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cartDal.GetAll();
        }

        public Cart GetById(int id)
        {
            return _cartDal.Get(c => c.Id == id);
        }

        public void PlaceOrder()
        {
            var activeCart = GetActiveCart();
            activeCart.Status = false;
            activeCart.TotalPrice = activeCart.CartItems.Sum(ci => ci.Subtotal);
            activeCart.CartItems.ToList().ForEach(ci => ci.Status = false);
            Update(activeCart);

            foreach(var item in activeCart.CartItems)
            {
                item.Status =false;
                _cartItemService.Update(item);
                _productService.UpdateProductStock(item.ProductId, item.Quantity);
            }

        }

        public void Update(Cart cart)
        {
            _cartDal.Update(cart);
        }

        
    }
}
