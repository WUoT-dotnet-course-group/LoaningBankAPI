using LoaningBank.CrossCutting.Enums;

namespace LoaningBank.CrossCutting.DTO
{
    public class GetOfferDTO
    {
        public Guid ID { get; set; }
        public OfferStatus Status { get; set; }
        public Guid InquiryID { get; set; }
    }
}