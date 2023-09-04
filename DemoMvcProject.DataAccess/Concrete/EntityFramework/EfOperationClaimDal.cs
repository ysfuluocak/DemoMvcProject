using DemoMvcProject.Core.DataAccess.Concrete.EntityFramework;
using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.DataAccess.Abstract;

namespace DemoMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim,AppDbContext>,IOperationClaimDal
    {

    }
}
