using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Model.Api.Requests;
using OSS.Model.DbModels;
using OSS.Model.ViewModels;

namespace OSS.Domain.Interfaces.Services
{
    public interface IImageService : IService<ImageDbModel, CreateImageRequest, UpdateImageRequest>
    {
        
    }
}