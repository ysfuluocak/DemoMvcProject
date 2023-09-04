using DemoMvcProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DemoMvcProject.DataAccess.Configuration
{
    public class ProductPhotoConfig : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.HasKey(ph => ph.Id);

        }
    }
}
