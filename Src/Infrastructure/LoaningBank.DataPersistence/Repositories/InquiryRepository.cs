using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.Enums;
using LoaningBank.DataPersistence.Utils;
using LoaningBank.Domain.Entities;
using LoaningBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoaningBank.DataPersistence.Repositories
{
    internal sealed class InquiryRepository : IInquiryRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public InquiryRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<Inquiry> Add(Inquiry inquiry)
        {
            var result = await _dbContext.Inquiries.AddAsync(inquiry);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Inquiry> GetById(Guid id) => await _dbContext.Inquiries.SingleAsync(x => x.ID == id);

        public async Task<PaginatedResponse<InquirySearch>> Get<TResult>(int pageIndex, int pageSize, SortOrder sortOrder, string sortHeader)
        {
            var query = _dbContext.InquirySearch.AsQueryable();

            if (sortOrder is not SortOrder.Undefined)
            {
                query = query.Sort<TResult, InquirySearch>(sortOrder, sortHeader);
            }

            return await query.Paginate(pageIndex, pageSize);
        }
    }
}
