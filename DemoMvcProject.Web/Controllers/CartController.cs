using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Web.Models.CartViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoMvcProject.Web.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICustomerService _customerService;
        public CartController(ICartService cartService, ICustomerService customerService)
        {
            _cartService = cartService;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var customerId = _customerService.GetByUserId(Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))).Data.Id;
            var cart = _cartService.GetActiveCartByCustomerId(customerId).Data;
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

        
        public IActionResult AddToCart(int id) //productId
        {
            var userIdString = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
            {
                TempData["LoginError"] = "Giriş yapınız";
                return RedirectToAction("Login", "Auth");
            }
            var userId = Convert.ToInt32(userIdString);
            _cartService.AddToCart(userId, id);
            return RedirectToAction("Index");

        }


        public IActionResult PlaceOrder()
        {
            var customerId = _customerService.GetByUserId(Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))).Data.Id;
            var result = _cartService.PlaceOrder(customerId);
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["OrderError"] = result.Message;
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(int id) //produtcId
        {
            var customerId = _customerService.GetByUserId(Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))).Data.Id;
            _cartService.DeleteToCart(customerId, id);
            return RedirectToAction("Index");
        }
    }
}
