using LoaningBank.Domain.Entities;

namespace LoaningBank.Domain.Repositories
{
    public interface IInquiryRepository
    {
        Task<IEnumerable<Inquiry>> GetAll();
    }
}
