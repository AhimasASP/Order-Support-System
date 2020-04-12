using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Domain.Interfaces.Services
{
    public interface IOrderService : IService<OrderModel, CreateOrderRequest, UpdateOrderRequest>
    {
      
    }
}