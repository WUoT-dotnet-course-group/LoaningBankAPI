using LoaningBank.Domain.Entities;
using LoaningBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoaningBank.DataPersistence.Repositories
{
    internal sealed class InquiryRepository : IInquiryRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public InquiryRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Inquiry>> GetAll() => await _dbContext.Inquiries.ToListAsync();
    }
}
