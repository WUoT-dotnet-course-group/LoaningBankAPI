using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.Enums;
using LoaningBank.Domain.Entities;
using LoaningBank.Domain.Repositories;
using LoaningBank.Services.Abstract;
using Mapster;

namespace LoaningBank.Services
{
    internal sealed class OfferService : IOfferService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OfferService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    
        public async Task Add(AddOfferDTO offer)
        {
            var offerToAdd = offer.Adapt<Offer>();
            offerToAdd.Status = OfferStatus.Pending;

            await _repositoryManager.OfferRepository.Add(offerToAdd);
        }
    }
}
