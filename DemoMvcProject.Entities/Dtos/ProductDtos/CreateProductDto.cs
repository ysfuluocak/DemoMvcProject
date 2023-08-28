using DemoMvcProject.Core.Entities.Abstract;


namespace DemoMvcProject.Entities.Dtos.ProductDtos
{
    public class CreateProductDto : IDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

    }
}
