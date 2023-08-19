using DemoMvcProject.Core.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepositoryBase<Product>
    {
        IEnumerable<ProductDetailsDto> GetAllProductDetailsDto();
        ProductDetailsDto GetProductDetails(int id);
    }
}
