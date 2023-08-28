using DemoMvcProject.Business.Abstract;
using DemoMvcProject.Business.Concrete;
using DemoMvcProject.Business.Validation.FluentValidation;
using DemoMvcProject.DataAccess;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace DemoMvcProject.Business
{
    public static class ServicesBll
    {
        public static void AddScopedBll(this IServiceCollection services)
        {
            services.AddScopedDal();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICartItemService,CartItemManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IProductPhotoService, ProductPhotoManager>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ProductValidator>();


        }
    }
}