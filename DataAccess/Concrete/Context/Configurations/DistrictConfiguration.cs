using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Context.Configurations
{
  public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(d =>d.Id);
            builder.Property(d => d.Id).UseIdentityColumn();
            builder.HasOne(d => d.City)
                .WithMany(c => c.Districts) 
                .HasForeignKey(d => d.SehirId)
                .HasPrincipalKey(c =>c.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        
        }
    }
}