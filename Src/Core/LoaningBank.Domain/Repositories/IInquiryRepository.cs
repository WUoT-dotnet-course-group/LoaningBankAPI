using LoaningBank.Domain.Entities;

namespace LoaningBank.Domain.Repositories
{
    public interface IInquiryRepository
    {
        Task<Inquiry> Add(Inquiry inquiry);
        Task<List<Inquiry>> GetAll();
    }
}
