using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }
    }
}
