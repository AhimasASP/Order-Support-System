using System.Threading;
using System.Threading.Tasks;

namespace OSS.Data.Interfaces
{
    public interface IFileRepository
    {
        Task AddFileAsync(string fileBody, string fileId, CancellationToken token);

        Task<string> GetFileAsync(string filePath, CancellationToken token);
    }
}