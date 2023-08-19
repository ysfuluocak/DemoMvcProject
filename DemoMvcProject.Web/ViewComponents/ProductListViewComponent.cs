using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcProject.Web.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductListViewComponent(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = _productService.GetAllProductDetails();
            var productsvm = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsvm.Add(new ProductViewModel()
                {
                    ProductName = product.ProductName,
                    CategoryName = product.CategoryName,
                    Description = product.Description,
                    Price = product.Price,
                    Id = product.Id,
                    Stock = product.Stock

                });
            }
            

            return await Task.FromResult(View(productsvm));
        }
    }
}
    