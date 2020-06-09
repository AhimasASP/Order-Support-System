using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
using OSS.Domain.Models.ApiModels;
using ServiceStack;

namespace OSS.Domain.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;

        public SearchService(IItemRepository itemRepository, IOrderRepository orderRepository)
        {
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
        }

        public async Task<List<BaseDbModel>> SearchAsync(string param, CancellationToken token)
        {
            var searingParams = param.Split("|");

            var searchValue = searingParams[0].ToLower();
            var searchRegion = searingParams[1];

            var searchList = new List<BaseDbModel>();

            switch (searchRegion)

            {
                case "order" : 
                    searchList.AddRange(await GetSearchOrderListAsync(searchValue, token));
                    break;
                case "item":
                    searchList.AddRange(await GetSearchItemListAsync(searchValue, token));
                    break;
            }
            
            return searchList;

        }

        private async Task<List<ItemDbModel>> GetSearchItemListAsync(string param, CancellationToken token)
        {

            List<SearchResponseModel> searchItemList = new List<SearchResponseModel>();

            var itemList = new List<ItemDbModel>();


            itemList.AddRange(await _itemRepository.GetFilteredAsync(_ =>
                _.Article.ToLower().Contains(param) ||
                _.Name.ToLower().Contains(param) ||
                _.Description.ToLower().Contains(param), token));

            foreach (var item in itemList)
            {
                searchItemList.Add(new SearchResponseModel()
                {
                    Type = "item",
                    Id = item.Id.ToString(),
                    Article = item.Article,
                    Name = item.Name,
                    Description = item.Description
                });
            }

            return itemList;
        }

        private async Task<List<OrderDbModel>> GetSearchOrderListAsync(string param, CancellationToken token)
        {
            List<SearchResponseModel> searchOrderList = new List<SearchResponseModel>();

            List<OrderDbModel> orderList = new List<OrderDbModel>();

            orderList.AddRange(await _orderRepository.GetFilteredAsync(_ =>
                _.Address.ToLower().Contains(param) || 
                _.ClientName.ToLower().Contains(param) || 
                _.OrderNumber.ToLower().Contains(param) ||
                _.Phone.ToLower().Contains(param), token));

            foreach (var order in orderList)
            {
                searchOrderList.Add(new SearchResponseModel()
                {
                    Type = "order",
                    Id = order.Id.ToString(),
                    Article = order.OrderNumber,
                    Name = order.ClientName,
                    Description = order.Address + " " + order.Phone
                });
            }

            return orderList;
        }
        }
}