using LoaningBank.CrossCutting.Enums;

namespace LoaningBank.Domain.Entities
{
    public class Offer
    {
        public Guid ID { get; set; }
        public OfferStatus Status { get; set; }
        public Guid InquiryID { get; set; }
        public Inquiry Inquiry { get; set; } = default!;
    }
}
