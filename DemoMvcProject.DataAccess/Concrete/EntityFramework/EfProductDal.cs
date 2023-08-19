using DemoMvcProject.Core.DataAccess.Concrete.EntityFramework;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.Entities.Concrete;
using DemoMvcProject.Entities.Dtos.ProductDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public IEnumerable<ProductDetailsDto> GetAllProductDetailsDto()
        {
            using (var context = new AppDbContext())
            {
                var products = context.Set<Product>().Include(c => c.Category).Where(p=>p.Status).Select(p => new ProductDetailsDto()
                {
                    Id = p.Id,
                    CategoryName = p.Category.CategoryName,
                    Description = p.Description,
                    Price = p.Price,
                    ProductName = p.ProductName,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId
                }).ToList();
                return products;
            }
        }

        public ProductDetailsDto GetProductDetails(int id)
        {
            using (var context = new AppDbContext())
            {
                var product = context.Set<Product>().Include(c => c.Category).SingleOrDefault(p => p.Id == id && p.Status);
                return new ProductDetailsDto()
                {
                    Id = product.Id,
                    CategoryName = product.Category.CategoryName,
                    Description = product.Description,
                    Price = product.Price,
                    ProductName = product.ProductName,
                    Stock = product.Stock,
                    CategoryId = product.CategoryId
                };
            }
        }
    }
}
