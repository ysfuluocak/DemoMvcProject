using DemoMvcProject.Core.DataAccess.Concrete.EntityFramework;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DemoMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, AppDbContext>, ICartDal
    {
        public Cart GetActiveCart()
        {
            using (var context = new AppDbContext())
            {
                var cart = context.Set<Cart>()
                    .Include(c => c.CartItems)
                    .SingleOrDefault(c => c.Status);

                if (cart != null)
                {
                    cart.CartItems = cart.CartItems.Where(ci => ci.Status).ToList();
                }

                return cart;
            }
        }
    }
}
