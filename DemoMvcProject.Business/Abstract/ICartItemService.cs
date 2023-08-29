using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Entities.Concrete;
using IResult = DemoMvcProject.Core.Utilities.Results.IResult;

namespace DemoMvcProject.Business.Abstract
{
    public interface ICartItemService
    {
        IDataResult<IEnumerable<CartItem>> GetAll();
        IDataResult<CartItem> GetById(int id);
        IResult Update(CartItem cartItem);
        IResult Delete(CartItem cartItem);
        IResult Add(CartItem cartItem);
    }
}
