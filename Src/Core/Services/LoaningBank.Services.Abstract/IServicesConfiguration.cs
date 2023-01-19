namespace LoaningBank.Services.Abstract
{
    public interface IServicesConfiguration
    {
        public string DatabaseConnectionString { get; }
        public string BlobStorageConnectionString { get; }
        public string BlobContainerName { get; }
        public string AuthSecretKey { get; }
        public KeyValuePair<string, string> AdminClientCredentails { get; }
        public KeyValuePair<string, string> ClientCredentails { get; }
    }
}
