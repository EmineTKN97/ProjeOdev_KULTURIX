using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.Concrete.Context.Configurations
{
    public class BlogLikeConfiguration : IEntityTypeConfiguration<BlogLike>
    {
        public void Configure(EntityTypeBuilder<BlogLike> builder)
        {

            builder.HasKey(l => l.LikeId);
            builder
                        .HasOne(l => l.blog)
                        .WithMany(b => b.BlogLikes)
                        .HasForeignKey(l => l.BlogId)
                       .OnDelete(DeleteBehavior.ClientSetNull);


            builder
                      .HasOne(l => l.comment)
                      .WithMany(c => c.BlogLikes)
                      .HasForeignKey(l => l.BlogCommentId)
                      .HasPrincipalKey(c => c.CommentId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(l => l.User)
               .WithMany(u => u.BlogLikes)
               .HasForeignKey(l => l.UserId)
               .HasPrincipalKey(u => u.Id)
              .OnDelete(DeleteBehavior.ClientSetNull);





        }
    }
}