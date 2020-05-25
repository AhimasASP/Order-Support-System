using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Common.Constants;
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
        private readonly IFileRepository _fileRepository;

        public ImageService(IImageRepository imageRepository, IFileRepository fileRepository)
        {
            _imageRepository = imageRepository;
            _fileRepository = fileRepository;
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

        public async Task<string> GetAsync(string id, CancellationToken token)
        {
            var filePath = ConstantsValue.ImagePath + @"\Processed\" + id + ".jpg";
            return await _fileRepository.GetFileAsync(filePath, token);
        }

        public Task<List<string>> GetListAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ImageDbModel>> GetFilteredAsync(string owner, CancellationToken token)
        {
            return await _imageRepository.GetFilteredAsync(_ => _.Owner == owner , token);
        }


        public Task<ImageDbModel> UpdateAsync(string id, UpdateImageRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(string id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}