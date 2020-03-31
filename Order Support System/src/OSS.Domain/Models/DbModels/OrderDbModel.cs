using System;
using System.Collections.Generic;
using System.Text;
using OSS.Domain.Common.Constats;

namespace OSS.Domain.Common.Models.DbModels
{
    public class OrderDbModel : BaseDbModel
    {
        public OrderStatus Status { get; set; }
        public string DesignerId { get; set; }
        public string Address { get; set; }
        public string ClientName { get; set; }
        public string OrderDate { get; set; }
        public string Phone { get; set; }
        public string OrderNumber { get; set; }
        public string PaymentType { get; set; }
        public bool IsCredit { get; set; }
        public byte CreditMonthCount { get; set; }
        public double FinalSum { get; set; }
        public string Comment { get; set; }
        //public ICollection<string> Calculations { get; set; }
    }
}
