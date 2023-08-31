using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Core.Entities.Enums;
using DemoMvcProject.Core.Extensions;
using DemoMvcProject.Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoMvcProject.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;

        public AuthController(IAuthService authService, IUserService userService, ICustomerService customerService)
        {
            _authService = authService;
            _userService = userService;
            _customerService = customerService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _authService.Login(model);
            if (!user.Success)
            {
                TempData["LoginError"] = user.Message;
                return View(model);
            }
            var operationClaims = _userService.GetClaims(model);
            if (!operationClaims.Success)
            {
                TempData["LoginError"] = operationClaims.Message;
            }
            var customer = _customerService.GetByUserId(user.Data.Id);
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Data.Id.ToString());
            claims.AddEmail(user.Data.Email);
            claims.AddName($"{user.Data.FirstName} {user.Data.LastName}");
            claims.AddRoles(operationClaims.Data.Select(role => role.Name).ToArray());

            if (customer.Success)
            {
                claims.AddCustomerId(customer.Data?.Id.ToString());
            }

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _authService.Register(model);
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["RegisterError"] = result.Message;
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [Authorize(Roles ="Member")]
        public IActionResult Profile()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Profile()
        //{
        //    return View();
        //}
    }
}
