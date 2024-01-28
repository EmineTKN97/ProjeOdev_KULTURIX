using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.Concrete.Context.Configurations
{
    internal class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(m => m.MediaId);
           builder
                   .HasOne(m => m.blog)
                   .WithMany(b => b.Medias)
                   .HasForeignKey(m => m.BlogId)
                   .HasPrincipalKey(b => b.BlogId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(m => m.User)
               .WithMany(u => u.Medias)
               .HasForeignKey(bc => bc.UserId)
               .HasPrincipalKey(c => c.Id)
              .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}