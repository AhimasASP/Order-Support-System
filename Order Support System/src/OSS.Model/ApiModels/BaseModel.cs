using System;
using System.Collections.Generic;
using System.Text;

namespace OSS.Domain.Models.ApiModels
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string CreationTime { get; set; }
        public  string ModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
