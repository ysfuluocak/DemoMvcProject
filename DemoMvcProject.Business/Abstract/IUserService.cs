using DemoMvcProject.Core.Entities.Concrete;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Entities.Dtos.UserDtos;

namespace DemoMvcProject.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<IEnumerable<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByEMail(string email);
        IDataResult<int> Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        IDataResult<IEnumerable<OperationClaim>> GetClaims(UserForLoginDto userForLoginDto);
    }
}
