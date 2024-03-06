using DataAccess.Concrete.Context.Configurations;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class ProjeOdevContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=EMINE;Initial Catalog=ProjeDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BlogCommentConfiguration());
            modelBuilder.ApplyConfiguration(new BlogLikeConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new AdminOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new CostConfiguration());

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogLike> BlogLikes { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Announcement> Announcements{ get; set; }
        public   DbSet<Admin> Admins { get; set; }  
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<AdminOperationClaim> AdminOperationClaims { get; set; }
        public  DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Cost> Costs { get; set; }
    }
}
