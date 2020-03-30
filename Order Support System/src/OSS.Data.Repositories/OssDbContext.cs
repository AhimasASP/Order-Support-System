using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Models;

namespace OSS.WebApplication.Configurations.Entity
{
    public class OssDbContext : DbContext, IOssDbContext
    {
        public OssDbContext(DbContextOptions<OssDbContext> options) : base(options)
        {
            //Database.EnsureCreatedAsync();
        }


        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<OrderDbModel> Orders { get; set; }
        public DbSet<CalculationDbModel> Calculation { get; set; }
        public DbSet<ItemDbModel> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<ItemDbModel>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }

       

    }
}
