using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.DbModels;
using OSS.WebApplication.Configurations.Entity;

namespace OSS.Data.Repositories
{
    public class OrderRepository : BaseEntityRepository<OrderDbModel>, IOrderRepository
    {
        public OrderRepository(OssDbContext dbContext) : base(dbContext)
        {
        }
    }
}