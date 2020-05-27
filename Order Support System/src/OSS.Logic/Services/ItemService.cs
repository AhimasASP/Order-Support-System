using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using OSS.Common.Constants;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Domain.Interfaces.Services;
using ServiceStack;

namespace OSS.Domain.Logic.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        private readonly IImageService _imageService;
        private readonly IFileRepository _fileRepository;

        public ItemService(IItemRepository repository, IImageService imageService, IFileRepository fileRepository)
        {
            _repository = repository;
            _imageService = imageService;
            _fileRepository = fileRepository;
        }

        public async Task<ItemModel> CreateAsync(CreateItemRequest request, CancellationToken token)
        {
            var item = new ItemDbModel
            {
                Article = request.Article,
                Name = request.Name,
                Description = request.Description,
                Size = request.Size,
                Currency = request.Currency,
                PurchasePrice = request.PurchasePrice,
                Price = request.Price,
                Photo = request.Photo,
                CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Type = request.Type
            };

            await _repository.CreateAsync(item, token);
            return item.ConvertTo<ItemModel>();
        }

        public async Task<ItemModel> GetAsync(Guid itemId, CancellationToken token)
        {

            var item = (await _repository.GetAsync(itemId, token)).ConvertTo<ItemModel>();
            if (item == null)
            {
                return null;
            }
            var images = await _imageService.GetFilteredAsync(itemId.ToString(), token);
            var imagesAsBase64Array = new string[images.Count];
            int i = 0;
            foreach (var image in images)
            {
                imagesAsBase64Array[i] = await _fileRepository.GetFileAsync(ConstantsValue.ImagePath + @"\Cropped\" + image.Id + ".jpg", token) + "|||" + image.Id;
                i++;
            }

            item.Images = imagesAsBase64Array;

            return item;
        }

        public async Task<List<ItemModel>> GetListAsync(CancellationToken token)
        {
             return (await _repository.GetListAsync(token)).ConvertTo<List<ItemModel>>();
        }

        public async Task<List<ItemModel>> GetFilteredAsync(string param, CancellationToken token)
        {
            param = param.ToLower();

            List<ItemDbModel> list =  await _repository.GetFilteredAsync(_=>_.Article.ToLower().Contains(param), token);

            if (list.Count != 0) return list.ConvertTo<List<ItemModel>>();

            list = await _repository.GetFilteredAsync(_ => _.Name.ToLower().Contains(param), token);

            if (list.Count != 0) return list.ConvertTo<List<ItemModel>>();

            list = await _repository.GetFilteredAsync(_ => _.Description.ToLower().Contains(param), token);

            return list.ConvertTo<List<ItemModel>>();

        }


        public async Task<ItemModel> UpdateAsync(Guid id, UpdateItemRequest request, CancellationToken token)
        {
            var model = await _repository.GetAsync(id, token);

                model.Article = request.Article;
                model.Name = request.Name;
                model.Description = request.Description;
                model.PurchasePrice = request.PurchasePrice;
                model.Price = request.Price;
                model.Photo = request.Photo;
                model.Type = request.Type;
                model.ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                await _repository.UpdateAsync(model, token);
            return model.ConvertTo<ItemModel>();
        }

        public async Task<List<ItemModel>> SearchAsync(string param, CancellationToken token)
        {
            List<ItemDbModel> orderList = new List<ItemDbModel>();

            orderList.AddRange(await _repository.GetFilteredAsync(_ =>
                _.Article.ToLower().Contains(param) ||
                _.Type.ToLower().Contains(param) ||
                _.Name.ToLower().Contains(param) ||
                _.Description.ToLower().Contains(param), token));

            return orderList.ConvertTo<List<ItemModel>>();
        }

        public async Task<string> DeleteAsync(Guid itemId, CancellationToken token)
        {
            
            return await _repository.DeleteAsync(itemId, token);
        }
    }
}
