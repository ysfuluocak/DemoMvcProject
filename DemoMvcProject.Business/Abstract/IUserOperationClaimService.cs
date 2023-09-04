using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.Core.Utilities.Results;

namespace DemoMvcProject.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult Add(UserOperationClaim claim);
        IResult Update(UserOperationClaim claim);
        IResult Delete(UserOperationClaim claim);

    }
}
