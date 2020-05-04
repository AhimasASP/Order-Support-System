namespace OSS.Domain.Common.Models.Api.Requests
{
    public class UpdateItemRequest
    {
        public string Article { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Currency { get; set; }
        public double PurchasePrice { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public string Type { get; set; }
    }
}