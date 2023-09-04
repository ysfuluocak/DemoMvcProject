using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Entities.Concrete;

namespace DemoMvcProject.Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<IEnumerable<Customer>> GetAll();
        IDataResult<Customer> Get(int customerId);
        IDataResult<int> Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);

        IDataResult<Customer> GetByUserId(int userId);


    }
}
