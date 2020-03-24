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

        Task<OrderModel> GetAsync(string orderId, CancellationToken token);

        Task<List<OrderModel>> GetListAsync(string field, string value, CancellationToken token);


        Task<OrderModel> UpdateAsync(UpdateOrderRequest request, CancellationToken token);
        Task<string> DeleteAsync(string id, CancellationToken token);
    }
}