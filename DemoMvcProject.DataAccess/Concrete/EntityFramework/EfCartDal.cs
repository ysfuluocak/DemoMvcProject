using DemoMvcProject.Core.DataAccess.Concrete.EntityFramework;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, AppDbContext>, ICartDal
    {
        public Cart GetActiveCart()
        {
            using(var context = new AppDbContext())
            {
                var cart = context.Set<Cart>().Include(c => c.CartItems).SingleOrDefault(c => c.Status);
                return cart;
            }
        }
    }
}
