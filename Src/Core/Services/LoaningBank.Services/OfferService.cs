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
    
        public async Task Add(string inquiryId)
        {
            var offerToAdd = new Offer
            {
                InquiryID = Guid.Parse(inquiryId),
                Status = OfferStatus.Pending
            };

            await _repositoryManager.OfferRepository.Add(offerToAdd);
        }

        public async Task<List<GetOfferDTO>> GetAll()
        {
            var offers = await _repositoryManager.OfferRepository.GetAll();
            return offers.Adapt<List<GetOfferDTO>>();
        }
    }
}
