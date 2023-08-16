using DemoMvcProject.Core.Entities.Abstract;

namespace DemoMvcProject.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}