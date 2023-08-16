using DemoMvcProject.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Core.DataAccess.Abstract
{
    public interface IEntityRepositoryBase<T> where T : BaseEntity, new()
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
