using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Web.Models.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcProject.Web.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesvm = new List<CategoryViewModel>();
            var categories = _categoryService.GetAllPublished().Data;
            foreach (var category in categories)
            {
                categoriesvm.Add(new CategoryViewModel()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });
            }
            return await Task.FromResult(View(categoriesvm));
        }
    }
}
