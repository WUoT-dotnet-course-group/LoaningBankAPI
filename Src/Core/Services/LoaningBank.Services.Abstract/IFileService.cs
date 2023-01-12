namespace LoaningBank.Services.Abstract
{
    public interface IFileService
    {
        public Task UploadFile(Stream fileStream, string filename);
        public Task<Stream> DownloadFile(string filename);
    }
}
