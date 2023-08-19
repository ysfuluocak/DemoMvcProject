using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Web.Models.ProductViewModels;
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
            var product = new CreateProductViewModel()
            {
                Categories = new SelectList(categories, "Id", "CategoryName")
            };
            return View(product);
        }

        [HttpPost]
        public IActionResult Add(CreateProductViewModel model)
        {
            var product = new Product()
            {
                ProductName = model.ProductName,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Price = model.Price,
                Stock = model.Stock
            };
            _productService.Add(product);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var product = _productService.GetProductDetails(id);
            var categories = _categoryService.GetAll();
            var updateProduct = new UpdateProductViewModel()
            {
                ProductId = id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                Categories = new SelectList(categories, "Id", "CategoryName", product.CategoryId)
            };
            return View(updateProduct);
        }

        [HttpPost]
        public IActionResult Update(UpdateProductViewModel model)
        {
            var product = new Product()
            {
                ProductName = model.ProductName,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Price = model.Price,
                Stock = model.Stock
            };
            _productService.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetProductDetails(id);
            var productvm = new ProductViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                CategoryName = product.CategoryName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };
            return View(productvm);
        }

        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            _productService.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
