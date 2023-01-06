using LoaningBank.CrossCutting.Enums;

namespace LoaningBank.Domain.Entities
{
    public class Offer
    {
        public Guid ID { get; set; }
        public int LoanValue { get; set; }
        public short LoanPeriod { get; set; }
        public OfferStatus Status { get; set; }
        public float Percentage { get; set; }
        public float MonthlyInstallment { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? ApprovedBy { get; set; }
        public string DocumentLink { get; set; } = default!;
        public DateTime DocumentLinkValidDate { get; set; }

        public Guid InquiryID { get; set; }
        public virtual Inquiry Inquiry { get; set; } = default!;
    }
}
