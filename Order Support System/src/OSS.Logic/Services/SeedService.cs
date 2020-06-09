using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSS.Common.Constants;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Common.SeedData;
using OSS.Domain.Interfaces.Services;
using OSS.Logic.Services.Helpers;
using OSS.Model.Api.Requests;
using OSS.Model.DbModels;
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
        private readonly IImageRepository _imageRepository;
        private readonly IFileRepository _fileRepository;

        private readonly ImageConverter _imageConverter;

        public SeedService(OssDbContext dbContext, IRoleRepository roleRepository, IUserRepository userRepository, IItemRepository itemRepository, IOrderRepository orderRepository, IImageRepository imageRepository, IFileRepository fileRepository, ImageConverter imageConverter)
        {
            _dbContext = dbContext;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _imageRepository = imageRepository;
            _fileRepository = fileRepository;
            this._imageConverter = imageConverter;
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
                 if (order.DesignerId == null)
                 {
                     var user =  await _userRepository.GetFilteredAsync(_ => _.UserName.ToLower() == "designer");
                     order.DesignerId = user[0].Id;
                 }
                     
                 order.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                 order.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                 await _orderRepository.CreateAsync(order, CancellationToken.None);
             }

        }

        public async Task SeedImages()
        {            
            if (await _dbContext.Images.AnyAsync()) return;

            var owner = await _orderRepository.GetFilteredAsync(
                _ => _.OrderNumber == "dog111-1111", CancellationToken.None);

            var imageSeedPaths = Directory.GetFiles(ConstantsValue.ImageSeedPath);
           
            foreach (var path in imageSeedPaths)
            {
                var imageDbModel = new ImageDbModel
                {
                    Owner = owner[0].Id.ToString(),
                    CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                var imageId = await _imageRepository.CreateAsync(imageDbModel, CancellationToken.None);

                var imageStream = await _fileRepository.GetFileAsync(path, CancellationToken.None);

                await _fileRepository.AddFileAsync(imageStream, imageId, CancellationToken.None);

                await _imageConverter.ResizeTo800X600(ConstantsValue.ImagePath + imageId + ".jpg");
            }
        }
    }

}