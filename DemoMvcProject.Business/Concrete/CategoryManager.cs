using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Constants;
using DemoMvcProject.Core.Utilities.Results;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;

namespace DemoMvcProject.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            category.Status = false;
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<IEnumerable<Category>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Category>>(_categoryDal.GetAll(),Messages.CategoryListed);
        }

        public IDataResult<IEnumerable<Category>> GetAllPublished()
        {
            return new SuccessDataResult<IEnumerable<Category>>(_categoryDal.GetAll().Where(x => x.Status),Messages.PublishCategoryListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == id),Messages.CategoryShown);
        }

        public IDataResult<Category> GetPublished(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == id && c.Status),Messages.PublishCategoryShown);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }

}
