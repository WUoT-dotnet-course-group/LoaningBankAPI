using LoaningBank.Domain.Repositories;
using LoaningBank.Services.Abstract;

namespace LoaningBank.Services
{
    internal sealed class OfferService : IOfferService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OfferService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    }
}
