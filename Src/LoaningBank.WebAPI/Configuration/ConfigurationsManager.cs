using LoaningBank.Services.Abstract;

namespace LoaningBank.WebAPI.Configuration
{
    public class ConfigurationsManager : IServicesConfiguration
    {
        private readonly DatabaseConfig _databaseConfig;
        private readonly BlobStorageConfig _blobStorageConfig;
        private readonly AuthConfig _authConfig;

        public readonly IConfiguration Configuration;

        public ConfigurationsManager(IConfiguration configuration)
        {
            Configuration = configuration;
            _databaseConfig = Configuration.GetRequiredSection(DatabaseConfig.SectionName).Get<DatabaseConfig>();
            _blobStorageConfig = Configuration.GetRequiredSection(BlobStorageConfig.SectionName).Get<BlobStorageConfig>();
            _authConfig = Configuration.GetRequiredSection(AuthConfig.SectionName).Get<AuthConfig>();
        }

        public string DatabaseConnectionString
        {
            get
            {
                return $"Server={_databaseConfig.Server};Initial Catalog={_databaseConfig.DbName};" +
                    $"Persist Security Info=False;" +
                    $"User ID={_databaseConfig.Login};Password={_databaseConfig.Password};" +
                    $"MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=15;";
            }
        }

        public string BlobStorageConnectionString
        {
            get
            {
                return $"DefaultEndpointsProtocol=https;AccountName={_blobStorageConfig.Name};" +
                    $"AccountKey={_blobStorageConfig.Key};EndpointSuffix=core.windows.net";
            }
        }

        public string BlobContainerName => _blobStorageConfig.ContainerName;

        public string AuthSecretKey => _authConfig.AuthSecretKey;

        public KeyValuePair<string, string> AdminClientCredentails => new(_authConfig.AdminClientId, _authConfig.AdminClientSecret);

        public KeyValuePair<string, string> ClientCredentails => new(_authConfig.ClientId, _authConfig.ClientSecret);
    }
}
