using DemoMvcProject.Core.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;

namespace DemoMvcProject.DataAccess.Abstract
{
    public interface ICartItemDal : IEntityRepositoryBase<CartItem>
    {
    }
}
