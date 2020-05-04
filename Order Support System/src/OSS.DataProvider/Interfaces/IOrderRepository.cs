using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Data.Interfaces
{
    public interface IOrderRepository : IRepository<OrderDbModel>
    {
        
    }
}