using DemoMvcProject.DataAccess.Abstract;
using DemoMvcProject.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;


namespace DemoMvcProject.DataAccess
{
    public static class ServicesDal
    {
        public static void AddScopedDal(this IServiceCollection services)
        {
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICartItemDal, EfCartItemDal>();
            services.AddScoped<ICartDal, EfCartDal>();
            services.AddScoped<IProductPhotoDal, EfProductPhoto>();
        }
    }
}
