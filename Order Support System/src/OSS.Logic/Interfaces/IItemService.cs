using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;

namespace OSS.Domain.Interfaces.Services
{
    public interface IItemService : IService<ItemModel, CreateItemRequest, UpdateItemRequest>
    {
    
    }
}