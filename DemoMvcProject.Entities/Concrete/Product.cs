using DemoMvcProject.Core.Entities.Abstract;

namespace DemoMvcProject.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public Product()
        {
            CreatedDate = DateTime.Now;
            Status = true;
            Photos = new HashSet<ProductPhoto>();  
        }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductPhoto> Photos { get; set; }

    }
}
