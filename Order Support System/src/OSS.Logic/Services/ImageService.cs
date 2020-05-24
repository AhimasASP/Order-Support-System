using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Data.Interfaces;
using OSS.Domain.Interfaces.Services;
using OSS.Model.Api.Requests;
using OSS.Model.DbModels;
using OSS.Model.ViewModels;
using ServiceStack;

namespace OSS.Logic.Services
{
    public class ImageService : IImageService
    {

        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<ImageDbModel> CreateAsync(CreateImageRequest request, CancellationToken token)
        {
            var image = new ImageDbModel
            {
                Owner = request.Owner,
                CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ModificationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            image.Id = await _imageRepository.CreateAsync(image, token);

            return image;
        }

        public Task<ImageDbModel> GetAsync(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImageDbModel>> GetListAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ImageDbModel>> GetFilteredAsync(string owner, CancellationToken token)
        {
            return await _imageRepository.GetFilteredAsync(_ => _.Owner == owner , token);
        }


        public Task<ImageDbModel> UpdateAsync(Guid id, UpdateImageRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}