using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductPhotoDtos;
using Microsoft.AspNetCore.Http;

namespace DemoMvcProject.Business.Abstract
{
    public interface IProductPhotoService
    {
        IEnumerable<ProductPhoto> GetProductPhotosByProductId(int productId);
        ProductPhoto GetProductPhotoByPhotoId(int photoId);
        IEnumerable<ProductPhoto> GetProductPhotosByProductIdPublished(int productId);
        ProductPhoto GetProductPhotoByProductIdPublished(int photoId);
        void Add(ProductPhoto photo,IFormFile file);
        void Update(UpdateProductPhotoDto photo,IFormFile file);
        int Delete(int photoId);
    }
}
