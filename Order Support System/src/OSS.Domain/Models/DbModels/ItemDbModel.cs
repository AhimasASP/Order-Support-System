using System;
using System.Collections.Generic;
using System.Text;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Domain.Common.Models.ApiModels
{
    public class ItemDbModel : BaseDbModel
    {

        public string Article { get; set; }
        public string  Name { get; set; }
        public string  Description { get; set; }
        public double PurchasePrice { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public string CreationDate { get; set; }
        public string ModificationDate { get; set; }
        public string Type { get; set; }
    }
}
