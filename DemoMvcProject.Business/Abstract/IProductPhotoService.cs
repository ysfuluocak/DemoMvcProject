using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductPhotoDtos;
using Microsoft.AspNetCore.Http;
using IResult = DemoMvcProject.Core.Utilities.Results.IResult;

namespace DemoMvcProject.Business.Abstract
{
    public interface IProductPhotoService
    {
        IDataResult<IEnumerable<ProductPhoto>> GetProductPhotosByProductId(int productId);
        IDataResult<ProductPhoto> GetProductPhotoByPhotoId(int photoId);
        IDataResult<IEnumerable<ProductPhoto>> GetProductPhotosByProductIdPublished(int productId);
        IDataResult<ProductPhoto> GetProductPhotoByProductIdPublished(int photoId);
        IResult Add(ProductPhoto photo, IFormFile file);
        IResult Update(UpdateProductPhotoDto photo, IFormFile file);
        IDataResult<int> Delete(int photoId);
    }
}
