using DemoMvcProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcProject.DataAccess.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey("Id");
            builder.HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);
            builder.HasData(new Product()
            {
                ProductName = "Telefon",
                Description = "Akıllı Telefon",
                Price = 30000,
                Stock = 10,
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                Status = false
            });
        }
    }
}
