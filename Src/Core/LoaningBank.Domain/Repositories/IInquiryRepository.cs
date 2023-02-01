using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.Enums;
using LoaningBank.Domain.Entities;

namespace LoaningBank.Domain.Repositories
{
    public interface IInquiryRepository
    {
        Task<Inquiry> Add(Inquiry inquiry);
        Task<Inquiry> GetById(Guid id);
        Task<PaginatedResponse<InquirySearch>> Get<TResult>(int pageIndex, int pageSize, SortOrder sortOrder, string sortHeader, string filter);
    }
}
