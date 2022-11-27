namespace LoaningBank.CrossCutting.DTO
{
    public class GetInquiryDTO
    {
        public Guid ID { get; set; }
        public int LoanValue { get; set; }
        public short NumberOfInstallments { get; set; }
        public DateTime InquireDate { get; set; }
    }
}