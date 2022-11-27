using LoaningBank.Domain.Entities;

namespace LoaningBank.Domain.Repositories
{
    public interface IOfferRepository
    {
        Task Add(Offer offer);
    }
}
