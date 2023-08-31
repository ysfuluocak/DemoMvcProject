using DemoMvcProject.Core.DataAccess.Abstract;
using DemoMvcProject.Core.Entities.Concrete;

namespace DemoMvcProject.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepositoryBase<User>
    {
        IEnumerable<OperationClaim> GetClaims(User user);
    }
}
