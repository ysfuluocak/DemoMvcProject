using DemoMvcProject.Business.Abstract;
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

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            category.Status = false;
            _categoryDal.Update(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public IEnumerable<Category> GetAllPublished()
        {
            return _categoryDal.GetAll().Where(x => x.Status);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(c => c.Id == id);
        }

        public Category GetPublished(int id)
        {
            return _categoryDal.Get(c => c.Id == id && c.Status);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }

}
