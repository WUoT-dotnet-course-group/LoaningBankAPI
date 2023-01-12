using LoaningBank.Domain.Entities;
using LoaningBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoaningBank.DataPersistence.Repositories
{
    internal class OfferRepository : IOfferRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public OfferRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Add(Offer offer)
        {
            var result = await _dbContext.Offers.AddAsync(offer);
            await _dbContext.SaveChangesAsync();
            return result.Entity.ID;
        }

        public async Task<Offer> GetById(Guid id) => await _dbContext.Offers.SingleAsync(x => x.ID == id);

        public async Task<Guid> GetDocumentKey(Guid offerId)
        {
            var offer = await _dbContext.Offers.Select(x => new { x.ID, x.DocumentKey }).SingleAsync(x => x.ID == offerId);
            return offer.DocumentKey;
        }
    }
}
