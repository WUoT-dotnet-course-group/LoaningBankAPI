namespace LoaningBank.CrossCutting.DTO
{
    public class PersonalDataDTO
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; }
    }
}
