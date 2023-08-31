using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Entities.Concrete;
using IResult = DemoMvcProject.Core.Utilities.Results.IResult;

namespace DemoMvcProject.Business.Abstract
{
    public interface ICartService
    {
        IDataResult<IEnumerable<Cart>> GetAll();
        IDataResult<Cart> GetById(int id);
        IDataResult<Cart> GetActiveCartByCustomerId(int customerId);
        IDataResult<IEnumerable<Cart>> GetCartsByCustomerId(int customerId);
        IDataResult<Cart> Add(Cart cart);
        IResult Update(Cart cart);
        IResult Delete(Cart cart);
        IResult AddToCart(int userId, int productId);
        IResult PlaceOrder(int customerId);
        IResult DeleteToCart(int customerId, int productId);

    }
}
