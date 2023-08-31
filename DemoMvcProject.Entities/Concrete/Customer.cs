using DemoMvcProject.Core.Entities.Abstract;
using DemoMvcProject.Core.Entities.Concrete;

namespace DemoMvcProject.Entities.Concrete
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Status = true;
            CreatedDate = DateTime.Now;
            CustomerCarts = new HashSet<Cart>();
        }
        public string FullName { get; set; }
        public int UserId { get; set; }

        public ICollection<Cart> CustomerCarts { get; set; }
        public User User { get; set; }
    }
}
