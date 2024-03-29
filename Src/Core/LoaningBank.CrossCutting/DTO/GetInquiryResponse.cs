using LoaningBank.CrossCutting.Enums;
using System.Text.Json.Serialization;

namespace LoaningBank.CrossCutting.DTO
{
    public class GetInquiryResponse
    {
        [JsonPropertyName("inquireId")]
        public Guid ID { get; set; }

        [JsonPropertyName("createDate")]
        public DateTime InquireDate { get; set; }
        
        public Guid? OfferId { get; set; }

        [JsonPropertyName("statusId")]
        public OfferStatus OfferStatus { get; set; }

        [JsonPropertyName("statusDescription")]
        public string OfferStatusDescription { get; set; } = default!;
    }
}