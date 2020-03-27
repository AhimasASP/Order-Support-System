using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Interfaces.Services;

namespace OSS.Domain.Logic.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public Task<ItemModel> CreateAsync(CreateItemRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ItemModel> GetAsync(string itemId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemModel>> GetAllAsync(CancellationToken token)
        {
            var tmp = await _repository.GetListAsync(token);
            
            return new List<ItemModel>();
        }

        public Task<List<ItemModel>> GetFilteredAsync(string type, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ItemModel> UpdateAsync(UpdateItemRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(string id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
