using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Entities.Dtos.UserDtos;

namespace DemoMvcProject.Business.Abstract
{
    public interface IAuthService
    {
        IResult Register(UserForRegisterDto userDtos);
        IDataResult<User> Login(UserForLoginDto userDto);
    }
}
