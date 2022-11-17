namespace LoaningBank.WebAPI.Configuration
{
    public class ConfigurationManager
    {
        private readonly DatabaseConfig _databaseConfig;

        public readonly IConfiguration Configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            Configuration = configuration;
            _databaseConfig = Configuration.GetSection(DatabaseConfig.SectionName).Get<DatabaseConfig>();
        }

        public string DbConnectionString
        {
            get
            {
                return $"Server={_databaseConfig.Server};Initial Catalog={_databaseConfig.DbName};" +
                    $"Persist Security Info=False;" +
                    $"User ID={_databaseConfig.Login};Password={_databaseConfig.Password};" +
                    $"MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=15;";
            }
        }
    }
}
