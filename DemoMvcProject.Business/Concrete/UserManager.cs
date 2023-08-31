using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Dtos.UserDtos;

namespace DemoMvcProject.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<int> Add(User user)
        {
            var userId = _userDal.Add(user);
            return new SuccessDataResult<int>(userId);
        }

        public IResult Delete(User user)
        {
            user.Status = false;
            _userDal.Update(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<IEnumerable<User>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetByEMail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user == null)
            {
                return new ErrorDataResult<User>(user, Messages.UserNotExist);
            }
            return new SuccessDataResult<User>(user, Messages.UserShown);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserShown);
        }

        public IDataResult<IEnumerable<OperationClaim>> GetClaims(UserForLoginDto userForLoginDto)
        {
            var user = GetByEMail(userForLoginDto.Email);
            if (user == null)
            {
                return new ErrorDataResult<IEnumerable<OperationClaim>>(user.Message);
            }
            var claims = _userDal.GetClaims(user.Data);
            if (claims == null)
            {
                return new ErrorDataResult<IEnumerable<OperationClaim>>(Messages.ClaimNotFountForUser);
            }
            return new SuccessDataResult<IEnumerable<OperationClaim>>(claims,Messages.ClaimsListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
