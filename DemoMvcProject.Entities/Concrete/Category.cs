using DemoMvcProject.Core.Entities.Abstract;

namespace DemoMvcProject.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public Category()
        {
            CreatedDate = DateTime.Now;
            Products = new HashSet<Product>();
            Status = true;
        }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}