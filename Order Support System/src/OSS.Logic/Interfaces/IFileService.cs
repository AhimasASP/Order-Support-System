using System.Threading;
using System.Threading.Tasks;

namespace OSS.Domain.Interfaces.Services
{
    public interface IFileService
    {
        Task AddFileAsync(string fileBody, string fileId, CancellationToken token);
        Task<string> GetFileAsync(string filePath, CancellationToken token);
    }
}