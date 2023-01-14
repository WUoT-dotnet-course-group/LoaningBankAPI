using LoaningBank.CrossCutting.Enums;

namespace LoaningBank.Domain.Entities
{
    public class InquirySearch
    {
        public Guid InquiryID { get; set; }
        public Guid? OfferID { get; set; }
        public int LoanValue { get; set; }
        public short NumberOfInstallments { get; set; }
        public DateTime InquireDate { get; set; }
        public OfferStatus? Status { get; set; }
        public float? Percentage { get; set; }
        public DateTime? OfferCreateDate { get; set; }
        public DateTime? OfferUpdateDate { get; set; }
        public string? ApprovedBy { get; set; }
    }
}
