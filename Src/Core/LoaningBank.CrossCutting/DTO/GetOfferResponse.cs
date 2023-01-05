using LoaningBank.CrossCutting.Enums;
using System.Text.Json.Serialization;

namespace LoaningBank.CrossCutting.DTO
{
    public class GetOfferResponse
    {
        [JsonPropertyName("id")]
        public Guid ID { get; set; }

        [JsonPropertyName("requestedValue")]
        public int LoanValue { get; set; }

        [JsonPropertyName("requestedPeriodInMonth")]
        public short LoanPeriod { get; set; }

        [JsonPropertyName("statusId")]
        public OfferStatus Status { get; set; }

        [JsonPropertyName("statusDescription")]
        public string OfferStatusDescription { get; set; } = default!;

        [JsonPropertyName("inquireId")]
        public Guid InquiryID { get; set; }

        public float Percentage { get; set; }
        public float MonthlyInstallment { get; set; }
        public string StatusDescription { get; set; } = default!;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ApprovedBy { get; set; } = default!;
        public string DocumentLink { get; set; } = default!;
        public DateTime DocumentLinkValidDate { get; set; }
    }
}