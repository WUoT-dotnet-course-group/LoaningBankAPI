namespace LoaningBank.WebAPI.Configuration
{
    internal class BlobStorageConfig
    {
        public const string SectionName = "BlobStorage";

        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string ContainerName { get; set; } = string.Empty;
    }
}
