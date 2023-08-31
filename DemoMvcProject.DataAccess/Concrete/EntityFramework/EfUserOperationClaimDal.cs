using DemoMvcProject.Core.DataAccess.Concrete.EntityFramework;
using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.DataAccess.Abstract;

namespace DemoMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim,AppDbContext>,IUserOperationClaimDal
    {

    }
}
