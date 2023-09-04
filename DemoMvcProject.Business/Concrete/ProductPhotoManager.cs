using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Utilities.Business;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductPhotoDtos;
using Microsoft.AspNetCore.Http;
using IResult = DemoMvcProject.Core.Utilities.Results.IResult;

namespace DemoMvcProject.Business.Concrete
{
    public class ProductPhotoManager : IProductPhotoService
    {
        private readonly IProductPhotoDal _productPhotoDal;

        public ProductPhotoManager(IProductPhotoDal productPhotoDal)
        {
            _productPhotoDal = productPhotoDal;
        }

        public IResult Add(ProductPhoto photo, IFormFile file)
        {
            string path = ImageHelper.SaveImage(file);
            photo.ImagePath = path;
            _productPhotoDal.Add(photo);
            return new SuccessResult(Messages.ProductPhotoAdded);
        }

        public IDataResult<int> Delete(int photoId)
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
            return new SuccessDataResult<int>(photo.ProductId,Messages.ProductPhotoDeleted);
        }

        public IDataResult<ProductPhoto> GetProductPhotoByPhotoId(int photoId)
        {
            return new SuccessDataResult<ProductPhoto>(_productPhotoDal.Get(ph=>ph.Id == photoId),Messages.ProductPhotoShown);
        }

        public IDataResult<ProductPhoto> GetProductPhotoByProductIdPublished(int photoId)
        {
            return new SuccessDataResult<ProductPhoto>(_productPhotoDal.Get(ph=>ph.Id==photoId & ph.Status),Messages.PublishProductPhotoShown);
        }

        public IDataResult<IEnumerable<ProductPhoto>> GetProductPhotosByProductId(int productId)
        {
            return new SuccessDataResult<IEnumerable<ProductPhoto>>(_productPhotoDal.GetAll(ph=>ph.ProductId == productId),Messages.ProductPhotosListed);
        }

        public IDataResult<IEnumerable<ProductPhoto>> GetProductPhotosByProductIdPublished(int productId)
        {
            return new SuccessDataResult<IEnumerable<ProductPhoto>>(_productPhotoDal.GetAll(ph=>ph.ProductId == productId & ph.Status),Messages.PublishProductPhotosListed);
        }

        public IResult Update(UpdateProductPhotoDto photo,IFormFile file)
        {
            var productPhoto = _productPhotoDal.Get(ph=>ph.Id == photo.ProductPhotoId);
            productPhoto.ImagePath = ImageHelper.UpdateImage(file, productPhoto.ImagePath);
            _productPhotoDal.Update(productPhoto);
            return new SuccessResult(Messages.ProductPhotoUpdated);
        }
    }
}
