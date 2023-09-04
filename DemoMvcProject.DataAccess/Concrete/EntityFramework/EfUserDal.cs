using DemoMvcProject.Core.DataAccess.Concrete.EntityFramework;
using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.DataAccess.Abstract;

namespace DemoMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, AppDbContext>, IUserDal
    {
        public IEnumerable<OperationClaim> GetClaims(User user)
        {
            using var context = new AppDbContext();

            var userClaims = from userOperationClaim in context.Set<UserOperationClaim>()
                             join operationClaim in context.Set<OperationClaim>()
                             on userOperationClaim.OperationClaimId equals operationClaim.Id
                             where userOperationClaim.UserId == user.Id
                             select operationClaim;

            return userClaims.ToList();
        }
    }
}
