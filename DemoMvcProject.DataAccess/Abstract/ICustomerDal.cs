using DemoMvcProject.Core.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;

namespace DemoMvcProject.DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepositoryBase<Customer>
    {

    }
}
