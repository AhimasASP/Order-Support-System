using System;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using OSS.Common.Constants;
using OSS.Data.Interfaces;

namespace OSS.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        public async Task AddFileAsync(string fileBody, string fileId, CancellationToken token)
        {
            var bytes = Convert.FromBase64String(fileBody);

                await File.WriteAllBytesAsync(ConstantsValue.ImagePath + fileId + ".jpg", bytes, token);
        }

        public async Task<string> GetFileAsync(string filePath, CancellationToken token)
        {
            var bytes = await File.ReadAllBytesAsync(filePath, token);

            return Convert.ToBase64String(bytes);
        }
    }
}