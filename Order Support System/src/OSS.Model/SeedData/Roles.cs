using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OSS.WebApplication.Configurations.Entity
{
    public class Roles
    {
        public readonly List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole {Name = "user"},
            new IdentityRole {Name = "admin"}
        };
    }
}