using DemoMvcProject.Entities.Concrete;

namespace DemoMvcProject.Business.Abstract
{
    public interface ICartItemService
    {
        IEnumerable<CartItem> GetAll();
        CartItem GetById(int id);
        void Update(CartItem cartItem);
        void Delete(CartItem cartItem);
        void Add(CartItem cartItem);
    }
}
