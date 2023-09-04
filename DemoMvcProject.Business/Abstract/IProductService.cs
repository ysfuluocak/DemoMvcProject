using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using IResult = DemoMvcProject.Core.Utilities.Results.IResult;

namespace DemoMvcProject.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<IEnumerable<Product>> GetAll();
        IDataResult<Product> GetById(int id);
        IDataResult<IEnumerable<ProductDetailsDto>> GetAllProductDetails();
        IDataResult<ProductDetailsDto> GetProductDetails(int id);
        IResult Add(CreateProductDto product, IFormFile file);
        IResult Update(UpdateProductDto product);
        IResult Delete(Product product);
        IResult UpdateProductStock(int productId, int quantityChange);
    }
}
