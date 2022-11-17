using LoaningBank.Domain.Repositories;

namespace LoaningBank.DataPersistence.Repositories
{
    internal sealed class InquiryRepository : IInquiryRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public InquiryRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    }
}
