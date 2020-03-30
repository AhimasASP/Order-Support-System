using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Domain.Models


{
    public interface IOssDbContext
    {
         DbSet<UserDbModel> Users { get; set; }
         DbSet<OrderDbModel> Orders { get; set; }
         DbSet<CalculationDbModel> Calculation { get; set; }
         DbSet<ItemDbModel>Items { get; set; }
         Task<int> SaveChangesAsync(CancellationToken token);


    }
}