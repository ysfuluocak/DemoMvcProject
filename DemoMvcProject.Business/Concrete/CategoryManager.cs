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
            _categoryDal.Delete(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(c => c.Id == id);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }

}
