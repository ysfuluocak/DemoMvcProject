using DemoMvcProject.Core.Entities.Abstract;


namespace DemoMvcProject.Entities.Concrete
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
            CreatedDate = DateTime.Now;
            Status = false;
        }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
