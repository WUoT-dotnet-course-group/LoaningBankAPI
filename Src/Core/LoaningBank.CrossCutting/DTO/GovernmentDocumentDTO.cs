using LoaningBank.CrossCutting.Enums;
using System.Text.Json.Serialization;

namespace LoaningBank.CrossCutting.DTO.LoaningBank
{
    public class GovernmentDocumentDTO
    {
        [JsonPropertyName("typeId")]
        public GovernmentIdType GovernmentIdType { get; set; }
        public string Number { get; set; } = default!;
    }
}
