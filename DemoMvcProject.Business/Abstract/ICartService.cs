using DemoMvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Business.Abstract
{
    public interface ICartService
    {
        IEnumerable<Cart> GetAll();
        Cart GetById(int id);
        Cart GetActiveCart();
        Cart Add(Cart cart);
        void Update(Cart cart);
        void Delete(Cart cart);
        void AddToCart(int ProductId);
        void PlaceOrder();

    }
}
