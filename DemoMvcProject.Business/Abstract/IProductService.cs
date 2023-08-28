using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;

namespace DemoMvcProject.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<IEnumerable<Product>> GetAll();
        IDataResult<Product> GetById(int id);
        IDataResult<IEnumerable<ProductDetailsDto>> GetAllProductDetails();
        IDataResult<ProductDetailsDto> GetProductDetails(int id);
        Core.Utilities.Results.IResult Add(CreateProductDto product, IFormFile file);
        Core.Utilities.Results.IResult Update(UpdateProductDto product);
        Core.Utilities.Results.IResult Delete(Product product);
        Core.Utilities.Results.IResult UpdateProductStock(int productId, int quantityChange);
    }
}
