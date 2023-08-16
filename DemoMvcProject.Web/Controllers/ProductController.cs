using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMvcProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Add()
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productService.Add(product);
            return RedirectToAction("Index");
        }
    }
}
