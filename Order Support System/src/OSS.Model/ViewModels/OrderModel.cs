using OSS.Common.Constants;
using OSS.Domain.Models.ApiModels;

namespace OSS.Domain.Common.Models.DbModels
{
    public class OrderModel : BaseModel
    {
        public OrderStatus Status { get; set; }
        public string DesignerId { get; set; }
        public string Address { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public string OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string PaymentType { get; set; }
        public bool IsCredit { get; set; }
        public byte CreditMonthCount { get; set; }
        public double FinalSum { get; set; }
        public string Comment { get; set; }
        public string[] Images { get; set; }
        //public ICollection<string> Calculations { get; set; }
    }
}
