using LoaningBank.CrossCutting.Enums;
using LoaningBank.CrossCutting.Utils;

namespace LoaningBank.CrossCutting.DTO
{
    public class GetInquiryDetailsResponse
    {
        public Guid InquiryID { get; set; }
        public Guid? OfferID { get; set; }

        [SortHeader("loanValue")]
        [EntityPropertyName("LoanValue")]
        public int LoanValue { get; set; }

        [SortHeader("numberOfInstallments")]
        [EntityPropertyName("NumberOfInstallments")]
        public short NumberOfInstallments { get; set; }

        [SortHeader("inquireDate")]
        [EntityPropertyName("InquireDate")]
        public DateTime InquireDate { get; set; }

        public OfferStatus Status { get; set; }

        [SortHeader("status")]
        [EntityPropertyName("Status")]
        public string StatusDescription { get; set; } = default!;

        [SortHeader("percentage")]
        [EntityPropertyName("Percentage")]
        public float? Percentage { get; set; }

        [SortHeader("offerCreateDate")]
        [EntityPropertyName("OfferCreateDate")]
        public DateTime? OfferCreateDate { get; set; }

        [SortHeader("offerUpdateDate")]
        [EntityPropertyName("OfferUpdateDate")]
        public DateTime? OfferUpdateDate { get; set; }

        [SortHeader("approvedBy")]
        [EntityPropertyName("ApprovedBy")]
        public string? ApprovedBy { get; set; }
    }
}
