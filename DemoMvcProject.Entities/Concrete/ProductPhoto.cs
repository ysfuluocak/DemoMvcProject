using DemoMvcProject.Core.Entities.Abstract;

namespace DemoMvcProject.Entities.Concrete
{
    public class ProductPhoto : BaseEntity
    {
        public ProductPhoto()
        {
            Status = true;
            CreatedDate = DateTime.Now;
        }

        public string ImagePath { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
