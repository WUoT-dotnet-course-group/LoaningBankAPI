using LoaningBank.Domain.Entities;

namespace LoaningBank.Domain.Repositories
{
    public interface IOfferRepository
    {
        Task<Guid> Add(Offer offer);
        Task<Offer> GetById(Guid id);
        Task<Guid> GetDocumentKey(Guid offerId);
    }
}
