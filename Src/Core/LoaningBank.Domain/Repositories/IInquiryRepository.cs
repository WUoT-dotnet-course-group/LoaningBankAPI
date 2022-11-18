using LoaningBank.Domain.Entities;

namespace LoaningBank.Domain.Repositories
{
    public interface IInquiryRepository
    {
        Task Add(Inquiry inquiry);
        Task<List<Inquiry>> GetAll();
    }
}
