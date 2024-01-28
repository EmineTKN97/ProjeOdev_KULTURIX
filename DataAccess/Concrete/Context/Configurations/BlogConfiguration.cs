using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Concrete.Context.Configurations
{

    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.BlogId);

            builder.HasOne(b => b.User)
               .WithMany(u => u.Blogs)
               .HasForeignKey(b=> b.UserId)
               .HasPrincipalKey(c => c.Id)
              .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
