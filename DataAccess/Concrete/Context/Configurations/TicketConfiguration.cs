using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Context.Configurations
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);
            builder
               .HasOne(t => t.user)
               .WithMany(u => u.Tickets)
               .HasForeignKey(t => t.UserId)
               .HasPrincipalKey(u => u.Id)
               .OnDelete(DeleteBehavior.ClientSetNull);
            builder
              .HasOne(t => t.city)
              .WithMany(c => c.Tickets)
              .HasForeignKey(t => t.CityId)
              .HasPrincipalKey(c => c.CityId)
              .OnDelete(DeleteBehavior.ClientSetNull);
            builder
            .HasOne(t => t.District)
            .WithMany(c => c.Tickets)
            .HasForeignKey(t => t.DistrictId)
            .HasPrincipalKey(c =>  c.DistrictId)
            .OnDelete(DeleteBehavior.ClientSetNull);
            builder
 .HasOne(t => t.Cost)
 .WithMany(cs => cs.Tickets)
 .HasForeignKey(t => t.CostId)
 .HasPrincipalKey(cs => cs.Id)
 .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}