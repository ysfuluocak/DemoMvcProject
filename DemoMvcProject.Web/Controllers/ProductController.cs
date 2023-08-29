using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductDtos;
using DemoMvcProject.Entities.Dtos.ProductPhotoDtos;
using DemoMvcProject.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMvcProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductPhotoService _productPhotoService;

        public ProductController(IProductService productService, ICategoryService categoryService, IProductPhotoService productPhotoService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productPhotoService = productPhotoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            var categories = _categoryService.GetAll().Data;
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateProductDto model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryService.GetAll().Data;
                ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
                return View(model);
            }
            _productService.Add(model, file);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {

            var product = _productService.GetProductDetails(id).Data;
            var categories = _categoryService.GetAll().Data;
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName", product.CategoryId);
            var updateProduct = new UpdateProductDto()
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };
            return View(updateProduct);

        }

        [HttpPost]
        public IActionResult Update(UpdateProductDto model)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                try
                {
                    var product = _productService.GetProductDetails(id);
                    var photos = _productPhotoService.GetProductPhotosByProductIdPublished(id).Data.ToList();
                    var productvm = new ProductViewModel()
                    {
                        Id = product.Data.Id,
                        ProductName = product.Data.ProductName,
                        CategoryName = product.Data.CategoryName,
                        Description = product.Data.Description,
                        Price = product.Data.Price,
                        Stock = product.Data.Stock,
                        Photos = photos
                    };
                    return View(productvm);
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Yanlıs bir secim yaptınız!";
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id).Data;
            _productService.Delete(product);
            return RedirectToAction("Index");
        }


        //ProductPhoto
        #region ProductPhoto
        public IActionResult CreatePhoto(int id) //productId
        {
            var createPhoto = new CreateProductPhotoDto()
            {
                ProductId = id
            };

            return View(createPhoto);
        }

        [HttpPost]
        public IActionResult CreatePhoto(CreateProductPhotoDto model, IFormFile file)
        {

            var photo = new ProductPhoto()
            {
                ProductId = model.ProductId
            };
            _productPhotoService.Add(photo, file);
            return RedirectToAction("Details", new { id = model.ProductId });
        }



        public IActionResult UpdatePhoto(int id) //productPhotoId
        {
            var productPhoto = _productPhotoService.GetProductPhotoByProductIdPublished(id).Data;
            var updatedProductPhoto = new UpdateProductPhotoDto()
            {
                ImagePath = productPhoto.ImagePath,
                ProductId = productPhoto.ProductId,
                ProductPhotoId = id
            };

            return View(updatedProductPhoto);
        }

        [HttpPost]
        public IActionResult UpdatePhoto(UpdateProductPhotoDto model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                _productPhotoService.Update(model, file);
                return RedirectToAction("Details", new { id = model.ProductId });
            }
            return View(model);

        }

        public IActionResult DeletePhoto(int id) //photoId
        {

            int productId = _productPhotoService.Delete(id).Data;
            return RedirectToAction("Details", new { id = productId });
        }

        #endregion
    }
}
