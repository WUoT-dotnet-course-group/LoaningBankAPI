using System.Text.Json.Serialization;

namespace LoaningBank.CrossCutting.DTO.LoaningBank
{
    public class CreateInquiryResponse
    {
        [JsonPropertyName("inquireId")]
        public string InquiryId { get; set; } = default!;
        public DateTime CreateDate { get; set; }
    }
}
