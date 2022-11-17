using LoaningBank.Domain.Repositories;

namespace LoaningBank.DataPersistence.Repositories
{
    internal class OfferRepository : IOfferRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public OfferRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    }
}
