using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.WebApplication.Configurations.Entity
{
    public class Initializer
    {
        private readonly List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole {Name = "user"},
            new IdentityRole {Name = "admin"}
        };

        private readonly List<UserDbModel> users = new List<UserDbModel>
        {
            new UserDbModel()
            {
                UserName = "Admin",
                FirstName = "Alex",
                LastName = "Dutcher",
                PhoneNumber = "=37529 111 11 11",
                Email = "admin@oss.by",
                //CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                //ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            },
            new UserDbModel()
            {
                UserName = "Designer",
                FirstName = "Helen",
                LastName = "Golovach",
                PhoneNumber = "=37529 222 22 22",
                Email = "designer@oss.by",
                //CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                //ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            },
            new UserDbModel()
            {
                UserName = "Manager",
                FirstName = "Pamela",
                LastName = "Anderson",
                PhoneNumber = "=37529 333 33 33",
                Email = "manager@oss.by",
                //CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                //ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            }
        };

        private static readonly string defaultPassword = "Asddsa_123";

        public async Task RoleInitializer(OssDbContext context, RoleManager<IdentityRole> manager)
        {
            if (await context.Roles.AnyAsync()) return;

            foreach (var role in roles)
            {
                await manager.CreateAsync(role);
            }
        }

        public async Task UserInitializer(OssDbContext context, UserManager<UserDbModel> manager)
        {
            if (await context.Users.AnyAsync(_ => _.UserName == "Admin")) return;

            foreach (var user in users)
            {
               
                user.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                user.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
               await manager.CreateAsync(user, defaultPassword);

               if (user.UserName == "Admin")
               {
                   var result = await manager.AddToRoleAsync(user, "Admin");
                   user.Photo = "role added";
               }
            }

        }
    }


}