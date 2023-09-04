using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.Core.Utilities.Results;

namespace DemoMvcProject.Business.Abstract
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaim claim);
        IResult Delete(OperationClaim claim);
        IResult Update(OperationClaim claim);
    }
}
