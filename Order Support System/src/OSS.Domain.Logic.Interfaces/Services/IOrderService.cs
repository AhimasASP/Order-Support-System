using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderModel> CreateAsync(CreateOrderRequest request, CancellationToken token);

        Task<OrderModel> GetAsync(Guid id, CancellationToken token);

        Task<List<OrderModel>> GetListAsync(CancellationToken token);

        Task<List<OrderModel>> GetFilteredAsync(string status, CancellationToken token);

        Task<OrderModel> UpdateAsync(Guid id, UpdateOrderRequest request, CancellationToken token);

        Task<string> DeleteAsync(Guid id, CancellationToken token);
    }
}