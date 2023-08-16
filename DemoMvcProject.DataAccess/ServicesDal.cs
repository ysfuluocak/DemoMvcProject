using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.DataAccess.Concrete;
using DemoMvcProject.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.DataAccess
{
    public static class ServicesDal
    {
        public static void AddScopedDal(this IServiceCollection services)
        {
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
        }
    }
}
