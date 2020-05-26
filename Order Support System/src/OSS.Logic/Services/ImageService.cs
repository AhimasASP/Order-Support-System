using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Common.Constants;
using OSS.Data.Interfaces;
using OSS.Domain.Interfaces.Services;
using OSS.Logic.Services.Helpers;
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
        private readonly ImageConverter _converter;
        private readonly string _processedPath = ConstantsValue.ImagePath + @"\Processed\";
        private readonly string _croppedPath = ConstantsValue.ImagePath + @"\Cropped\";

            public ImageService(IImageRepository imageRepository, IFileRepository fileRepository, ImageConverter converter)
        {
            _imageRepository = imageRepository;
            _fileRepository = fileRepository;
            _converter = converter;
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
            await _fileRepository.AddFileAsync(request.Body, image.Id, token);
            await _converter.ResizeTo800X600(ConstantsValue.ImagePath + image.Id + ".jpg");


            return image;
        }

        public async Task<string> GetAsync(string id, CancellationToken token)
        {
            return await _fileRepository.GetFileAsync(_processedPath + id + ".jpg", token);
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

        public async Task<string> DeleteAsync(Guid id, CancellationToken token)
        {

            await _imageRepository.DeleteAsync(id, token);
            await _fileRepository.DeleteFileAsync(_processedPath + id.ToString() + ".jpg", token);
            await _fileRepository.DeleteFileAsync(_croppedPath + id.ToString() + ".jpg", token);

            return "Ok";
        }
    }
}