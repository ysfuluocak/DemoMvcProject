using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;


namespace DemoMvcProject.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public IResult Add(CartItem cartItem)
        {
            _cartItemDal.Add(cartItem);
            return new SuccessResult(Messages.CartItemAdded);
        }

        public IResult Delete(CartItem cartItem)
        {
            cartItem.Status = false;
            _cartItemDal.Update(cartItem);
            return new SuccessResult(Messages.CartItemDeleted);
        }

        public IDataResult<IEnumerable<CartItem>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<CartItem>>(_cartItemDal.GetAll(),Messages.CartItemsListed);
        }

        public IDataResult<CartItem> GetById(int id)
        {
            return new SuccessDataResult<CartItem>(_cartItemDal.Get(ci=>ci.Id == id),Messages.CartItemShown);
        }

        public IResult Update(CartItem cartItem)
        {
            _cartItemDal.Update(cartItem);
            return new SuccessResult(Messages.CartItemUpdated);
        }
    }
}
