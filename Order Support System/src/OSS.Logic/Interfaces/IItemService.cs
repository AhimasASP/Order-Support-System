using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;

namespace OSS.Domain.Interfaces.Services
{
    public interface IItemService
    {
        Task<ItemModel> CreateAsync(CreateItemRequest request, CancellationToken token);

        Task<ItemModel> GetAsync(Guid itemId, CancellationToken token);

        Task<List<ItemModel>> GetListAsync(CancellationToken token);

        Task<List<ItemModel>> GetFilteredAsync(string type, CancellationToken token);

        Task<ItemModel> UpdateAsync(Guid id, UpdateItemRequest request, CancellationToken token);

        Task<string> DeleteAsync(Guid id, CancellationToken token);
    }
}