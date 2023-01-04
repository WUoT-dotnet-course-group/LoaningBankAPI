using LoaningBank.CrossCutting.Enums;
using System.Text.Json.Serialization;

namespace LoaningBank.CrossCutting.DTO.LoaningBank
{
    public class JobDetailsDTO
    {
        [JsonPropertyName("typeId")]
        public JobType JobType { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime? JobEndDate { get; set; }
    }
}
