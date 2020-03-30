using OSS.Domain.Models.ApiModels;

namespace OSS.Domain.Common.Models.ApiModels
{
    public class ItemModel : BaseModel
    {
        public string Article { get; set; }
        public string  Name { get; set; }
        public string  Description { get; set; }
        public double PurchasePrice { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public string Type { get; set; }
    }
}
