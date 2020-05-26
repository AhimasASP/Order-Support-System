using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.DbModels;
using OSS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OSS.Common.Constants;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.ApiModels;
using OSS.WebApplication.Configurations.Entity;
using ServiceStack;

namespace OSS.Domain.Logic.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _repository;
        private readonly IImageService _imageService;
        private readonly IHttpContextAccessor _accessor;
        private readonly IFileRepository _fileRepository;

        public OrderService(IOrderRepository repository, IHttpContextAccessor accessor, IImageRepository imageRepository, IImageService imageService, IFileRepository fileRepository)
        {
            _repository = repository;
            _accessor = accessor;
            _imageService = imageService;
            _fileRepository = fileRepository;
        }

        public async Task<OrderModel> CreateAsync(CreateOrderRequest request, CancellationToken token)
        {
            var designerId = _accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string[] images = new[] {ConstantsValue.ImagePath};
            var model = new OrderDbModel()
            {
                DesignerId = designerId,
                Status = OrderStatus.New,
                CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Address = request.Address,
                ClientName = request.ClientName,
                Phone = request.Phone,
                OrderDate = request.OrderDate,
                OrderNumber = request.OrderNumber,
                PaymentType = request.PaymentType,
                IsCredit = request.IsCredit,
                CreditMonthCount = request.CreditMonthCount,
                FinalSum = request.FinalSum,
                Comment = request.Comment
            };

            await _repository.CreateAsync(model, token);

            return model.ConvertTo<OrderModel>();

        }

        public async Task<OrderModel> GetAsync(Guid id, CancellationToken token)
        {
            var order = (await _repository.GetAsync(id, token)).ConvertTo<OrderModel>();
            if (order == null)
            {
                return null;
            }
            var images = await _imageService.GetFilteredAsync(id.ToString(), token);
            var imagesAsBase64Array = new string[images.Count];
            int i = 0;
            foreach (var image in images)
            {
                imagesAsBase64Array[i] = await _fileRepository.GetFileAsync(ConstantsValue.ImagePath + @"\Cropped\" + image.Id + ".jpg", token) + "|||" + image.Id;
                i++;
            }

            order.Images = imagesAsBase64Array;

            return order;
        }

        public async Task<List<OrderModel>> GetListAsync(CancellationToken token)
        {
            return (await _repository.GetListAsync(token)).ConvertTo<List<OrderModel>>();
        }

        public Task<List<OrderModel>> GetFilteredAsync(string status, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> UpdateAsync(Guid id, UpdateOrderRequest request, CancellationToken token)
        {
            var model = await _repository.GetAsync(id, token);
            model.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            model.Status = request.Status;
            model.Address = request.Address;
            model.ClientName = request.ClientName;
            model.Phone = request.Phone;
            model.OrderDate = request.OrderDate;
            model.OrderNumber = request.OrderNumber;
            model.PaymentType = request.PaymentType;
            model.IsCredit = request.IsCredit;
            model.CreditMonthCount = request.CreditMonthCount;
            model.FinalSum = request.FinalSum;
            model.Comment = request.Comment;

            await _repository.UpdateAsync(model, token);

            return model.ConvertTo<OrderModel>();
        }

        public async Task<List<OrderModel>> SearchAsync(string param, CancellationToken token)
        {
          List<OrderDbModel> orderList = new List<OrderDbModel>();

            orderList.AddRange(await _repository.GetFilteredAsync(_ =>
                _.Address.ToLower().Contains(param) ||
                _.ClientName.ToLower().Contains(param) ||
                _.OrderNumber.ToLower().Contains(param) ||
                _.Phone.ToLower().Contains(param), token));

            return orderList.ConvertTo<List<OrderModel>>();
        }

        public async Task<string> DeleteAsync(Guid id, CancellationToken token)
        {
            return await _repository.DeleteAsync(id, token);
            
        }
    }
}