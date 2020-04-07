using System;
using System.Collections.Generic;
using System.Text;

namespace OSS.Domain.Common.Models.ApiModels
{
    public class CreateItemRequest
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
