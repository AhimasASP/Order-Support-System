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
            Database.EnsureCreatedAsync();
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<CalculationModel> Calculation { get; set; }
        public DbSet<ItemModel> Items { get; set; }

    }
}
