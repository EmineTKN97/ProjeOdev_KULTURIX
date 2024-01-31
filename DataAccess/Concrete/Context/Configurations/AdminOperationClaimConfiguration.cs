using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.Concrete.Context
{
    internal class AdminOperationClaimConfiguration : IEntityTypeConfiguration<AdminOperationClaim>
    {
        public void Configure(EntityTypeBuilder<AdminOperationClaim> builder)
        {
            builder.HasKey(adminop => adminop.Id);
            builder
            .HasOne(aoc => aoc.Admin)
            .WithMany(admin => admin.AdminOperationClaims)
            .HasForeignKey(aoc => aoc.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}