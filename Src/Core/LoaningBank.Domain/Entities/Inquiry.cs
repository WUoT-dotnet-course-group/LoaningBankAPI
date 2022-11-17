namespace LoaningBank.Domain.Entities
{
    public class Inquiry
    {
        public Guid ID { get; set; }
        public int LoanValue { get; set; }
        public short NumberOfInstallments { get; set; }
        public DateTime InquireDate { get; set; }
        public PersonalData PersonalData { get; set; } = default!;
        public Offer? Offer { get; set; }
    }
}
