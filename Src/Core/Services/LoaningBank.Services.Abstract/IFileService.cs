namespace LoaningBank.Services.Abstract
{
    public interface IFileService
    {
        public Task UploadFile(Stream fileStream, string filename);
    }
}
