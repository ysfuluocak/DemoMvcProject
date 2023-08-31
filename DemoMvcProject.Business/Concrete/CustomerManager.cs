using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;

namespace DemoMvcProject.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IUserService _userService;

        public CustomerManager(ICustomerDal customerDal, IUserService userService)
        {
            _customerDal = customerDal;
            _userService = userService;
        }

        public IDataResult<int> Add(Customer customer)
        {
            var user = _userService.GetById(customer.UserId);
            customer.FullName = user.Data.FirstName + " " + user.Data.LastName;
            var customerId = _customerDal.Add(customer);
            return new SuccessDataResult<int>(customerId, Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            customer.Status = false;
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<Customer> Get(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == customerId), Messages.CustomerShown);
        }

        public IDataResult<IEnumerable<Customer>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            var customer = _customerDal.Get(cu => cu.UserId == userId);
            if (customer == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }
            return new SuccessDataResult<Customer>(customer, Messages.CustomerShown);
        }

        public IResult Update(Customer customer)
        {
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
