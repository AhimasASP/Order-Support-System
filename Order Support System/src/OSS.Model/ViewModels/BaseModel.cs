using System;
using System.Collections.Generic;
using System.Text;

namespace OSS.Domain.Models.ApiModels
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string CreationDate { get; set; }
        public  string ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
