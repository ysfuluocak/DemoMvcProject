using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.Entities.Concrete;
using IResult = DemoMvcProject.Core.Utilities.Results.IResult;

namespace DemoMvcProject.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<IEnumerable<Category>> GetAll();
        IDataResult<Category> GetById(int id);
        IDataResult<IEnumerable<Category>> GetAllPublished();
        IDataResult<Category> GetPublished(int id);
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}
