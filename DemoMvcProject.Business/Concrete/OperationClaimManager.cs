using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;

namespace DemoMvcProject.Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IResult Add(OperationClaim claim)
        {
            _operationClaimDal.Add(claim);
            return new SuccessResult(Messages.ClaimAdded);
        }

        public IResult Delete(OperationClaim claim)
        {
            claim.Status = false;
            _operationClaimDal.Update(claim);
            return new SuccessResult(Messages.ClaimDeleted);
        }

        public IResult Update(OperationClaim claim)
        {
            _operationClaimDal.Update(claim );
            return new SuccessResult(Messages.ClaimUpdated);
        }
    }
}
