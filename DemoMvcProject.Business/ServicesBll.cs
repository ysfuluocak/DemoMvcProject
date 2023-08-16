using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Concrete;
using DemoMvcProject.DataAccess;
using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.Business
{
    public static class ServicesBll
    {
        public static void AddScopedBll(this IServiceCollection services)
        {
            services.AddScopedDal();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();

        }
    }
}
