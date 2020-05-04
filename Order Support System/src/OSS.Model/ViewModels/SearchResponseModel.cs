namespace OSS.Domain.Common.Models.ApiModels
{
    public class SearchResponseModel
    {
        public string Type { get; set; } // for type of search result (order/item)
        public string Id { get; set; } //for Id of Items and Orders
        public string Article { get; set; } //for Article of Items and OrderNumber of Orders
        public string Name { get; set; } //for Name of Items and ClientName of Orders
        public string Description { get; set; } //for Description of Items and Address+Phone+FinalSum of Orders

    }
}