using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class ProjeOdevContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=EMINE;Initial Catalog=ProjeDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
            .HasKey(b => new { b.BlogId});

            modelBuilder.Entity<BlogComment>()
                .HasKey(c => c.CommentId);

            modelBuilder.Entity<BlogComment>()
               .HasOne(bc => bc.blog)
               .WithMany(b => b.BlogComments)
               .HasForeignKey(bc => bc.BlogId)
              .HasPrincipalKey(b => new { b.BlogId });


        }
    
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
    }
}
