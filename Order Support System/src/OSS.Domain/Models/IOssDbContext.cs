using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Domain.Models


{
    public interface IOssDbContext
    {
         DbSet<UserModel> Users { get; set; }
         DbSet<OrderModel> Orders { get; set; }
         DbSet<CalculationModel> Calculation { get; set; }
         DbSet<ItemModel>Items { get; set; }
         Task<int> SaveChangesAsync(CancellationToken token);


    }
}