using Azure.Storage.Blobs;
using LoaningBank.Services.Abstract;

namespace LoaningBank.Services
{
    internal sealed class FileService : IFileService
    {
        private readonly BlobContainerClient _blobContainerClient;

        public FileService(BlobContainerClient blobContainerClient)
        {
            _blobContainerClient = blobContainerClient;
        }

        public async Task UploadFile(Stream fileStream, string filename)
        {
            var blobClient = _blobContainerClient.GetBlobClient(filename);
            await blobClient.UploadAsync(fileStream, overwrite: true);
        }

        public async Task<Stream> DownloadFile(string filename)
        {
            var blobClient = _blobContainerClient.GetBlobClient(filename);
            try
            {
                var content = await blobClient.DownloadAsync();
                return content.Value.Content; 
            }
            catch(Exception)
            {
                return Stream.Null;
            }
        }
    }
}
