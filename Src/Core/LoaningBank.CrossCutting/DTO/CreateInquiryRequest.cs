using System.Text.Json.Serialization;

namespace LoaningBank.CrossCutting.DTO.LoaningBank
{
    public class CreateInquiryRequest
    {
        [JsonPropertyName("value")]
        public int LoanValue { get; set; }
        [JsonPropertyName("installmentsNumber")]
        public short NumberOfInstallments { get; set; }
        public PersonalDataDTO PersonalData { get; set; } = default!;
        public GovernmentDocumentDTO GovernmentDocument { get; set; } = default!;
        public JobDetailsDTO JobDetails { get; set; } = default!;
    }
}
