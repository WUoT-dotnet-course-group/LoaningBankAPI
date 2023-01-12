using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;
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
    
        public async Task Add(string inquiryId, CreateInquiryRequest inquiryData)
        {
            var rand = new Random(inquiryId.GetHashCode());

            var percentage = (float)rand.Next(1000) / 100;

            var offerToAdd = new Offer
            {
                LoanValue = inquiryData.LoanValue,
                LoanPeriod = inquiryData.NumberOfInstallments,
                Status = OfferStatus.Pending,
                Percentage = percentage,
                MonthlyInstallment = (float)inquiryData.LoanValue / inquiryData.NumberOfInstallments * (1 + percentage / 100),
                DocumentLink = "",
                DocumentLinkValidDate = DateTime.MaxValue,
                InquiryID = Guid.Parse(inquiryId),
            };

            await _repositoryManager.OfferRepository.Add(offerToAdd);
        }

        public async Task<GetOfferResponse> GetById(string offerId)
        {
            var offer = await _repositoryManager.OfferRepository.GetById(Guid.Parse(offerId));
            return offer.Adapt<GetOfferResponse>();
        }
    }
}
