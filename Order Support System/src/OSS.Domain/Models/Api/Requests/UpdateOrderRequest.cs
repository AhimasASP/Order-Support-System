using System.Collections.Generic;

namespace OSS.Domain.Common.Models.Api.Requests
{
    public class UpdateOrderRequest
    {
        public string Id { get; set; }
        public string Status { get; set; }
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
        // public ICollection<string> Calculations { get; set; }
    }
}