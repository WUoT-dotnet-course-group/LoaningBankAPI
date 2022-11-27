using LoaningBank.CrossCutting.DTO;
using LoaningBank.Domain.Entities;

namespace LoaningBank.Domain.Repositories
{
    public interface IOfferRepository
    {
        Task Add(Offer offer);
        Task<List<Offer>> GetAll();
    }
}
