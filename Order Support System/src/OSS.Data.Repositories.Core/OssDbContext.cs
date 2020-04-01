using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Models;

namespace OSS.WebApplication.Configurations.Entity
{
    public class OssDbContext : IdentityDbContext, IOssDbContext
    {
        public OssDbContext(DbContextOptions<OssDbContext> options) : base(options)
        {
            Database.EnsureCreatedAsync().GetAwaiter().GetResult();
        }


        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<OrderDbModel> Orders { get; set; }
        public DbSet<CalculationDbModel> Calculations { get; set; }
        public DbSet<ItemDbModel> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<ItemDbModel>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<UserDbModel>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OrderDbModel>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }

       

    }
}
