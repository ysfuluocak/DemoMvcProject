using DemoMvcProject.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMvcProject.DataAccess.Configuration
{
    public class UserOperationConfig : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.Ignore(uoc => uoc.Id);

            builder.HasKey(uoc => new { uoc.UserId, uoc.OperationClaimId });

            builder.HasOne(uoc => uoc.User)
                .WithMany(u => u.Claims)
                .HasForeignKey(uoc => uoc.UserId);

            builder.HasOne(uoc => uoc.OperationClaim)
                    .WithMany(oc => oc.Users)
                    .HasForeignKey(uoc => uoc.OperationClaimId);

        }
    }
}
