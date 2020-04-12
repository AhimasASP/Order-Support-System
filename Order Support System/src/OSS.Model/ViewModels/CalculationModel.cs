using System;
using System.Collections.Generic;
using System.Text;
using OSS.Domain.Models.ApiModels;

namespace OSS.Domain.Common.Models.DbModels
{
    public class CalculationModel : BaseModel
    {
        public string Name { get; set; }
        public string CreationDate { get; set; }
     }
}
