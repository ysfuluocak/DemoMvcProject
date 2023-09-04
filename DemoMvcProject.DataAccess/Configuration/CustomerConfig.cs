using DemoMvcProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMvcProject.DataAccess.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            builder.HasMany(c => c.CustomerCarts)
                .WithOne(ct => ct.Customer)
                .HasForeignKey(ct => ct.CustomerId);
        }

    }
}
