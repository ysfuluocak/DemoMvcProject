using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.Core.Entities.Enums;
using DemoMvcProject.Core.Utilities.Business;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Core.Utilities.Security.Hashing;
using DemoMvcProject.Entities.Dtos.UserDtos;

namespace DemoMvcProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService, IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
        }

        public IDataResult<User> Login(UserForLoginDto userDto)
        {
            var userToCheck = _userService.GetByEMail(userDto.Email);
            
            if (!userToCheck.Success || !userToCheck.Data.Status)
            {
                return new ErrorDataResult<User>(Messages.UserNotExist);
            }

            if(!HashingHelper.VerifyPasswordHash(userDto.Password,userToCheck.Data.PasswordSalt,userToCheck.Data.PasswordHash))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data,Messages.LoginSuccessful);
        }

        public IResult Register(UserForRegisterDto userDtos)
        {
            var result = BusinessRules.Run(UserExist(userDtos.Email));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(userDtos.Password, out passwordSalt, out passwordHash);
            var user = new User()
            {
                FirstName = userDtos.FirstName,
                LastName = userDtos.LastName,
                Email = userDtos.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };
            var userId = _userService.Add(user).Data;

            var userOperationclaim = new UserOperationClaim()
            {
                UserId = userId,
                OperationClaimId = (int)UserRole.Member
            };
            _userOperationClaimService.Add(userOperationclaim);

            return new SuccessResult(Messages.UserAdded);

        }

        private IResult UserExist(string email)
        {
            if(_userService.GetByEMail(email).Success)
                return new ErrorResult(Messages.UserAlreadyExist);
            return new SuccessResult(Messages.UserNotExist);
        }
    }
}
