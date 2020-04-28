using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSS.Data.Interfaces;
using OSS.Domain.Common.SeedData;
using OSS.Domain.Interfaces.Services;
using OSS.WebApplication.Configurations.Entity;

namespace OSS.Domain.Logic.Services
{
    public class SeedService : ISeedService
    {
        private readonly OssDbContext _dbContext;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;

        public SeedService(OssDbContext dbContext, IRoleRepository roleRepository, IUserRepository userRepository, IItemRepository itemRepository, IOrderRepository orderRepository)
        {
            _dbContext = dbContext;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
        }

        public async Task SeedRoles()
        {
            Roles roles = new Roles();
            if (await _dbContext.Roles.AnyAsync()) return;

            foreach (var role in roles.roles)
            {
                await _roleRepository.CreateAsync(role);
            }
        }

        public async Task SeedUsers()
        {
            Users users = new Users();
            if (await _dbContext.Users.AnyAsync(_ => _.UserName == "Admin")) return;

            foreach (var user in users.users)
            {

                user.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                user.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                await _userRepository.CreateAsync(user);

                if (user.UserName == "Admin")
                {
                    await _userRepository.AddUserToRoleAsync(user.UserName, "admin");
                }
                else
                {
                    await _userRepository.AddUserToRoleAsync(user.UserName, "user");
                }
            }
        }

        public async Task SeedItems()
        {
            if (await _dbContext.Items.AnyAsync()) return;
            Items items = new Items();

            foreach (var item in items.items)
            {
                item.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                item.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                await _itemRepository.CreateAsync(item, CancellationToken.None);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task SeedOrders()
        {
            if (await _dbContext.Orders.AnyAsync()) return;
             Orders orders = new Orders();

             foreach (var order in orders.orders)
             {
                 order.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                 order.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                 await _orderRepository.CreateAsync(order, CancellationToken.None);
             }

        }
    }

}