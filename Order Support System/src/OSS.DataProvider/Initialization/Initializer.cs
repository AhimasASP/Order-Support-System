using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.WebApplication.Configurations.Entity
{
    public class Initializer
    {
        private readonly Users _users = new Users();
        private readonly List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole {Name = "user"},
            new IdentityRole {Name = "admin"}
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

            foreach (var user in _users.users)
            {
               
                user.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                user.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
               await manager.CreateAsync(user, defaultPassword);

               if (user.UserName == "Admin")
               {
                   await manager.AddToRoleAsync(user, "Admin");
               }
               else
               {
                   await manager.AddToRoleAsync(user, "User");
               }
            }
        }

        public async Task ItemInitializer(OssDbContext context)
        {
            if (await context.Items.AnyAsync()) return;
            Items items = new Items();

            foreach (var item in items.items)
            {
                item.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                item.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                await context.Items.AddAsync(item);
            }

            await context.SaveChangesAsync();
        }
    }


}