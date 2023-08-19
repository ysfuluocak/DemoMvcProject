using DemoMvcProject.Core.DataAccess.Concrete.EntityFramework;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DemoMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfCartItemDal : EfEntityRepositoryBase<CartItem,AppDbContext>,ICartItemDal
    {

    }
}
