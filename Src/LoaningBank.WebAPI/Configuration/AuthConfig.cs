namespace LoaningBank.WebAPI.Configuration
{
    internal class AuthConfig
    {
        public static string SectionName => "Auth";

        public string AuthSecretKey { get; set; } = default!;
        public string AdminClientId { get; set; } = default!;
        public string AdminClientSecret { get; set; } = default!;
        public string ClientId { get; set; } = default!;
        public string ClientSecret { get; set; } = default!;
    }
}
