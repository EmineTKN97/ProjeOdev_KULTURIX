using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.Concrete.Context.Configurations
{
    internal class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(uoc => uoc.Id);

            builder
              .HasOne(uoc => uoc.User)
              .WithMany(user => user.UserOperationClaims)
              .HasForeignKey(uoc => uoc.UserId)
              .OnDelete(DeleteBehavior.Cascade);
            

        }
    }
}