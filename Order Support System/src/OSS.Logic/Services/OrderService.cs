﻿using OSS.Domain.Common.Models.Api.Requests;
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
using OSS.WebApplication.Configurations.Entity;
using ServiceStack;

namespace OSS.Domain.Logic.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _repository;
        private readonly IHttpContextAccessor _accessor;

        public OrderService(IOrderRepository repository, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _accessor = accessor;
        }

        public async Task<OrderModel> CreateAsync(CreateOrderRequest request, CancellationToken token)
        {
            var designerId = _accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
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
            return (await _repository.GetAsync(id, token)).ConvertTo<OrderModel>();
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

        public async Task<string> DeleteAsync(Guid id, CancellationToken token)
        {
            return await _repository.DeleteAsync(id, token);
            
        }
    }
}