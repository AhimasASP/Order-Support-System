using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OSS.Domain.Models.ApiModels
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public bool IsValid { get; set; } = true;
        public string CreationDate { get; set; }
        public  string ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
