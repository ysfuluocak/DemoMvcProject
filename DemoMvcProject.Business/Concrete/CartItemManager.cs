using DemoMvcProject.Business.Abstract;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public void Add(CartItem cartItem)
        {
            _cartItemDal.Add(cartItem);
        }

        public void Delete(CartItem cartItem)
        {
            cartItem.Status = false;
            _cartItemDal.Update(cartItem);
        }

        public IEnumerable<CartItem> GetAll()
        {
            return _cartItemDal.GetAll();
        }

        public CartItem GetById(int id)
        {
            return _cartItemDal.Get(ci=>ci.Id == id);
        }

        public void Update(CartItem cartItem)
        {
            _cartItemDal.Update(cartItem);
        }
    }
}
