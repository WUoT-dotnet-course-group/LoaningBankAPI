namespace LoaningBank.CrossCutting.DTO
{
    public class AuthRequest
    {
        public string ClientId { get; set; } = default!;
        public string ClientSecret { get; set; } = default!;
    }
}
