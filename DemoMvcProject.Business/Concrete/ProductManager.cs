using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using IResult = DemoMvcProject.Core.Utilities.Results.IResult;


namespace DemoMvcProject.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProductPhotoService _productPhotoService;

        public ProductManager(IProductDal productDal, IProductPhotoService productPhotoService)
        {
            _productDal = productDal;
            _productPhotoService = productPhotoService;
        }

        public IResult Add(CreateProductDto product, IFormFile file)
        {
            var addedProduct = new Product()
            {
                ProductName = product.ProductName,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Stock = product.Stock
            };
            var productId = _productDal.Add(addedProduct);
            var photo = new ProductPhoto()
            {
                ProductId = productId
            };       
            _productPhotoService.Add(photo, file);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            product.Status = false;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<IEnumerable<Product>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<IEnumerable<ProductDetailsDto>> GetAllProductDetails()
        {
            return new SuccessDataResult<IEnumerable<ProductDetailsDto>>(_productDal.GetAllProductDetailsDto(),Messages.ProductListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id),Messages.ProductShown);
        }

        public IDataResult<ProductDetailsDto> GetProductDetails(int id)
        {
            return new SuccessDataResult<ProductDetailsDto>(_productDal.GetProductDetails(id),Messages.ProductShown);
        }

        public IResult Update(UpdateProductDto product)
        {
            var updatedProduct = GetById(product.ProductId).Data;
            updatedProduct.ProductName = product.ProductName ?? updatedProduct.ProductName;
            updatedProduct.Description = product.Description ?? updatedProduct.Description;
            updatedProduct.CategoryId = product.CategoryId ?? updatedProduct.CategoryId;
            updatedProduct.Price = product.Price ?? updatedProduct.Price;
            updatedProduct.Stock = product.Stock ?? updatedProduct.Stock;
            _productDal.Update(updatedProduct);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IResult UpdateProductStock(int productId, int quantityChange)
        {
            var product = GetById(productId).Data;
            var updatedProduct = new UpdateProductDto()
            {
                ProductId = productId,
                Stock = product.Stock
            };
            if (product != null)
            {
                updatedProduct.Stock -= quantityChange;
                Update(updatedProduct);
                return new SuccessResult(Messages.ProductStockUpdated);
            }
            return new ErrorResult(Messages.ProductStockNotUpdated);
        }
    }

}
