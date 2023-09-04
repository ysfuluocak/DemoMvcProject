using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;

namespace DemoMvcProject.Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim claim)
        {
            _userOperationClaimDal.Add(claim);
            return new SuccessResult(Messages.ClaimAddedToUser);
        }

        public IResult Delete(UserOperationClaim claim)
        {
            claim.Status = false;
            _userOperationClaimDal.Update(claim);
            return new SuccessResult(Messages.ClaimDeletedToUser);
        }

        public IResult Update(UserOperationClaim claim)
        {
            _userOperationClaimDal.Update(claim);
            return new SuccessResult(Messages.ClaimUpdatedToUser);
        }
    }
}
