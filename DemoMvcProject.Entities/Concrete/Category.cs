using DemoMvcProject.Core.Entities.Abstract;

namespace DemoMvcProject.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Status = false;
            CreatedDate = DateTime.Now;
        }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}