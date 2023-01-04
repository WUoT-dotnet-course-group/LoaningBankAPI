namespace LoaningBank.CrossCutting.DTO.LoaningBank
{
    public class CreateInquiryRequest
    {
        public int LoanValue { get; set; }
        public short NumberOfInstallments { get; set; }
        public PersonalDataDTO PersonalData { get; set; } = default!;
        public GovernmentDocumentDTO GovernmentDocument { get; set; } = default!;
        public JobDetailsDTO JobDetails { get; set; } = default!;
    }
}
