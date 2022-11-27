namespace LoaningBank.Domain.Entities
{
    public class PersonalData
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string GovernmentID { get; set; } = default!;
        public GovernmentIdType GovernmentIDType { get; set; }
    }
}
