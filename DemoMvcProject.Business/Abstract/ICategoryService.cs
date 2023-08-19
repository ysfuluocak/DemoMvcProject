using DemoMvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Business.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        IEnumerable<Category> GetAllPublished();
        Category GetPublished(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
