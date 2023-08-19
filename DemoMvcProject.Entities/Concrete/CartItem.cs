using DemoMvcProject.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Entities.Concrete
{
    public class CartItem : BaseEntity
    {
        public CartItem()
        {
            CreatedDate = DateTime.Now;
            Status = true;
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
