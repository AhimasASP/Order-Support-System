using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
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

        public async Task<List<SearchResponseModel>> SearchAsync(string param, CancellationToken token)
        {
            param = param.ToLower();

            List<SearchResponseModel> searchList = new List<SearchResponseModel>();
            searchList.AddRange(await GetSearchItemListAsync(param, token));
            searchList.AddRange(await GetSearchOrderListAsync(param, token));

            return searchList;

        }

        private async Task<List<SearchResponseModel>> GetSearchItemListAsync(string param, CancellationToken token)
        {
            List<SearchResponseModel> searchItemList = new List<SearchResponseModel>();
            List<ItemDbModel> itemList = new List<ItemDbModel>();

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
            
            return searchItemList;
        }

        private async Task<List<SearchResponseModel>> GetSearchOrderListAsync(string param, CancellationToken token)
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

            return searchOrderList;
        }
        }
}