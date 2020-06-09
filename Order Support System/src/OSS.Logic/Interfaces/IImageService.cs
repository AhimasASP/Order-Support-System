using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OSS.Domain.Common.Models.Api.Requests;
using OSS.Domain.Common.Models.ApiModels;
using OSS.Model.Api.Requests;
using OSS.Model.DbModels;
using OSS.Model.ViewModels;

namespace OSS.Domain.Interfaces.Services
{
    public interface IImageService 
    {
        Task<ImageDbModel> CreateAsync(CreateImageRequest request, CancellationToken token);

        Task<string> GetAsync(string id, CancellationToken token);

        Task<List<string>> GetListAsync(CancellationToken token);

        Task<List<ImageDbModel>> GetFilteredAsync(string param, CancellationToken token);

        Task<ImageDbModel> UpdateAsync(string id, UpdateImageRequest request, CancellationToken token);

        Task<string> DeleteAsync(Guid id, CancellationToken token);
    }
}