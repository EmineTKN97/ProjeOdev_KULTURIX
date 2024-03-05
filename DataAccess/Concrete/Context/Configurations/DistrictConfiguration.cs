using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Context.Configurations
{
  public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(d =>d.DistrictId);
            builder.Property(d => d.DistrictId).UseIdentityColumn();
            builder.HasOne(d => d.City)
                .WithMany(c => c.Districts) 
                .HasForeignKey(d => d.CityId)
                .HasPrincipalKey(c =>c.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        
        }
    }
}