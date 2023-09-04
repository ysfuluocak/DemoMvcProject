using DemoMvcProject.Core.Entities.Abstract;

namespace DemoMvcProject.Entities.Dtos.ProductPhotoDtos
{
    public  class UpdateProductPhotoDto : IDto
    {
        public int ProductId { get; set; }
        public int ProductPhotoId { get; set; }
        public string? ImagePath { get; set; }
    }
}
