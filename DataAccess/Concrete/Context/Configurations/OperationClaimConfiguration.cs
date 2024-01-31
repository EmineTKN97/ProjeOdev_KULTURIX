using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.Concrete.Context.Configurations
{
    internal class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(oc => oc.Id);
            builder
                  .HasMany(oc => oc.UserOperationClaims)
                  .WithOne(uoc => uoc.OperationClaim)
                  .HasForeignKey(uoc => uoc.OperationClaimsId);
            builder
                   .HasMany(oc => oc.AdminOperationClaims)
                   .WithOne(aoc => aoc.OperationClaim)
                   .HasForeignKey(aoc => aoc.OperationClaimsId);
        }
    }
}