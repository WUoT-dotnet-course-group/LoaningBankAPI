namespace LoaningBank.Services.Abstract
{
    public interface IInquiryService
    {
        Task<IEnumerable<Guid>> GetAllIds();
    }
}
