using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcProject.Web.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IProductPhotoService _productPhotoService;

        public ProductListViewComponent(IProductService productService, IProductPhotoService productPhotoService)
        {
            _productService = productService;
            _productPhotoService = productPhotoService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = _productService.GetAllProductDetails();
            
            var productsvm = new List<ProductViewModel>();
            foreach (var product in products.Data)
            {
                var photos = _productPhotoService.GetProductPhotosByProductIdPublished(product.Id).Data.ToList();
                productsvm.Add(new ProductViewModel()
                {
                    ProductName = product.ProductName,
                    CategoryName = product.CategoryName,
                    Description = product.Description,
                    Price = product.Price,
                    Id = product.Id,
                    Stock = product.Stock,
                    Photos = photos
                });
            }
            TempData["Success"] = products.Message;

            return await Task.FromResult(View(productsvm));
        }
    }
}
    