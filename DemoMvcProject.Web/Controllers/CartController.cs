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
            var cart = _cartService.GetActiveCart();
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
            TempData["AddToCart"] = "İşlem başarılı";
            return RedirectToAction("Index");

        }


        public IActionResult PlaceOrder()
        {
            _cartService.PlaceOrder();
            return RedirectToAction("Index", "Home");
        }
    }
}
