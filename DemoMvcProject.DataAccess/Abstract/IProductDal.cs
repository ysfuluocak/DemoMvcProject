using DemoMvcProject.Core.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepositoryBase<Product>
    {
    }
}
