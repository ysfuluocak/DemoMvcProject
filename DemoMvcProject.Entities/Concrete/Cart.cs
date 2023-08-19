using DemoMvcProject.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ICollection<CartItem> CartItems { get; set; }
    }
}
