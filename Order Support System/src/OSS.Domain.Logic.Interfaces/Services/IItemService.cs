using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;

namespace OSS.Domain.Interfaces.Services
{
    public interface IItemService
    {
        Task<ItemModel> CreateAsync(CreateItemRequest request, CancellationToken token);

        Task<ItemModel> GetAsync(string itemId, CancellationToken token);

        Task<List<ItemModel>> GetAllAsync(CancellationToken token);

        Task<List<ItemModel>> GetFilteredAsync(string type, CancellationToken token);

        Task<ItemModel> UpdateAsync(UpdateItemRequest request, CancellationToken token);

        Task<string> DeleteAsync(string id, CancellationToken token);
    }
}