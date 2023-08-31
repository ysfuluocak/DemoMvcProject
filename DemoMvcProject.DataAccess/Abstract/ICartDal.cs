using DemoMvcProject.Core.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;

namespace DemoMvcProject.DataAccess.Abstract
{
    public interface ICartDal : IEntityRepositoryBase<Cart>
    {
        Cart GetActiveCart(int customerId);
    }
}
