using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Core.Utilities.Business;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductPhotoDtos;
using Microsoft.AspNetCore.Http;

namespace DemoMvcProject.Business.Concrete
{
    public class ProductPhotoManager : IProductPhotoService
    {
        private readonly IProductPhotoDal _productPhotoDal;

        public ProductPhotoManager(IProductPhotoDal productPhotoDal)
        {
            _productPhotoDal = productPhotoDal;
        }

        public void Add(ProductPhoto photo, IFormFile file)
        {
            string path = ImageHelper.SaveImage(file);
            photo.ImagePath = path;
            _productPhotoDal.Add(photo);
        }

        public int Delete(int photoId)
        {
            var photo = _productPhotoDal.Get(ph => ph.Id == photoId);
            var productPhotos = _productPhotoDal.GetAll(ph => ph.ProductId == photo.ProductId).ToList();
            if (productPhotos.Count<=1)
            {
                throw new Exception("En az bir adet fotograf olmalıdır.");
            }
            ImageHelper.DeleteImage(photo.ImagePath);
            photo.Status = false;
            _productPhotoDal.Update(photo);
            return photo.ProductId;
        }

        public ProductPhoto GetProductPhotoByPhotoId(int photoId)
        {
            return _productPhotoDal.Get(ph=>ph.Id == photoId);
        }

        public ProductPhoto GetProductPhotoByProductIdPublished(int photoId)
        {
            return _productPhotoDal.Get(ph=>ph.Id==photoId & ph.Status);
        }

        public IEnumerable<ProductPhoto> GetProductPhotosByProductId(int productId)
        {
            return _productPhotoDal.GetAll(ph=>ph.ProductId == productId);
        }

        public IEnumerable<ProductPhoto> GetProductPhotosByProductIdPublished(int productId)
        {
            return _productPhotoDal.GetAll(ph=>ph.ProductId == productId & ph.Status);
        }

        public void Update(UpdateProductPhotoDto photo,IFormFile file)
        {
            var productPhoto = _productPhotoDal.Get(ph=>ph.Id == photo.ProductPhotoId);
            productPhoto.ImagePath = ImageHelper.UpdateImage(file, productPhoto.ImagePath);
            _productPhotoDal.Update(productPhoto);
        }
    }
}
