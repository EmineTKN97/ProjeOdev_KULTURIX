using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.Concrete.Context.Configurations
{
    public class BlogCommentConfiguration : IEntityTypeConfiguration<BlogComment>
    {
        public void Configure(EntityTypeBuilder<BlogComment> builder)
        {
            builder.HasKey(c => c.CommentId);
                    
                builder
               .HasOne(bc => bc.Blog)
                    .WithMany(b => b.BlogComments)
                    .HasForeignKey(bc => bc.BlogId)
                    .HasPrincipalKey(b => b.BlogId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            builder
    .HasOne(bc => bc.User)
    .WithMany(u => u.BlogComments)
    .HasForeignKey(bc => bc.UserId)
    .HasPrincipalKey(u => u.Id)
    .OnDelete(DeleteBehavior.ClientSetNull);



        }
    }
}