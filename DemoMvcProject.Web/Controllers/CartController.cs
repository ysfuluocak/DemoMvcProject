using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Web.Models.CartViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcProject.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetActiveCart().Data;
            var cartViewModel = new CartViewModel();

            if (cart is not null) //cart != null
            {
                cartViewModel.Id = cart.Id;

                var cartItemViewModels = cart.CartItems.Select(ci => new CartItemViewModel()
                {
                    ProductName = ci.ProductName,
                    Price = ci.Price,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Subtotal = ci.Subtotal
                }).ToList();

                cartViewModel.Items = cartItemViewModels;
                cartViewModel.Total = cartViewModel.Items.Sum(ci => ci.Subtotal);
            }

            return View(cartViewModel);
        }

        public IActionResult AddToCart(int id)
        {
            _cartService.AddToCart(id);
            return RedirectToAction("Index");

        }


        public IActionResult PlaceOrder()
        {
           var result = _cartService.PlaceOrder();
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["OrderError"] = result.Message;
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(int id) //produtcId
        {
            _cartService.DeleteToCart(id);
            return RedirectToAction("Index");
        }
    }
}
