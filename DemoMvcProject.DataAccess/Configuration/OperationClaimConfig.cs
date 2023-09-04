using DemoMvcProject.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMvcProject.DataAccess.Configuration
{
    public class OperationClaimConfig : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(oc=>oc.Id);
        }
    }
}
