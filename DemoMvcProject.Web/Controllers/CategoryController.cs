using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Web.Models.CategoryViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcProject.Web.Controllers
{
    [Authorize(Roles ="Admin,Member")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateCategoryViewModel model)
        {
            var category = new Category()
            {
                CategoryName = model.CategoryName
            };
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var category = _categoryService.GetPublished(id).Data;
            var categoryvm = new UpdateCategoryViewModel()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
            return View(categoryvm);
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryViewModel model)
        {
            var category = new Category()
            {
                CategoryName = model.CategoryName
            };
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id).Data;
            _categoryService.Delete(category);
            return RedirectToAction("Index");
        }
    }
}
