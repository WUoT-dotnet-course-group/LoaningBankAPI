using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;
using LoaningBank.CrossCutting.Enums;
using LoaningBank.Domain.Entities;
using LoaningBank.Domain.Repositories;
using LoaningBank.Services.Abstract;
using Mapster;
using System.Text;

namespace LoaningBank.Services
{
    internal sealed class OfferService : IOfferService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IServiceManager _serviceManager;

        public OfferService(IRepositoryManager repositoryManager, IServiceManager serviceManager)
        {
            _repositoryManager = repositoryManager;
            _serviceManager = serviceManager;
        }

        public async Task<Guid> Add(string inquiryId, CreateInquiryRequest inquiryData)
        {
            var rand = new Random(inquiryId.GetHashCode());

            var percentage = (float)rand.Next(1000) / 100;

            var offerToAdd = new Offer
            {
                LoanValue = inquiryData.LoanValue,
                LoanPeriod = inquiryData.NumberOfInstallments,
                Status = OfferStatus.Uncompleted,
                Percentage = percentage,
                MonthlyInstallment = (float)inquiryData.LoanValue / inquiryData.NumberOfInstallments * (1 + percentage / 100),
                DocumentLinkValidDate = DateTime.Now.AddHours(1),
                InquiryID = Guid.Parse(inquiryId),
            };

            return await _repositoryManager.OfferRepository.Add(offerToAdd);
        }

        public async Task GenerateDocument(Guid offerId)
        {
            var offer = await _repositoryManager.OfferRepository.GetById(offerId);
            var personalData = offer.Inquiry.PersonalData;

            var contentBuilder = new StringBuilder();

            #region Build document content
            contentBuilder.AppendLine("-------------------------------------------------------------------------------------------------");
            contentBuilder.AppendLine("--------------------------------------- LOAN ARRANGEMENT ----------------------------------------");
            contentBuilder.AppendLine("-------------------------------------------------------------------------------------------------");
            contentBuilder.AppendLine();
            contentBuilder.AppendLine();
            contentBuilder.AppendLine();
            contentBuilder.AppendLine("Debtor data");
            contentBuilder.AppendLine("-------------------------------------------------------------------------------------------------");
            contentBuilder.AppendLine();
            contentBuilder.AppendLine($"First name: {personalData.FirstName}");
            contentBuilder.AppendLine($"Last name: {personalData.LastName}");
            contentBuilder.AppendLine($"Birth date: {personalData.BirthDate.ToString("d")}");
            contentBuilder.AppendLine($"Government ID: {personalData.GovernmentId}");
            contentBuilder.AppendLine($"Government ID type: {personalData.GovernmentIdType}");
            contentBuilder.AppendLine();
            contentBuilder.AppendLine();
            contentBuilder.AppendLine("Loan data");
            contentBuilder.AppendLine("-------------------------------------------------------------------------------------------------");
            contentBuilder.AppendLine();
            contentBuilder.AppendLine($"Value: {offer.LoanValue}");
            contentBuilder.AppendLine($"Period: {offer.LoanPeriod}");
            contentBuilder.AppendLine($"Percentage: {offer.Percentage}");
            contentBuilder.AppendLine($"Monthly installment: {offer.MonthlyInstallment}");
            contentBuilder.AppendLine();
            contentBuilder.AppendLine();
            contentBuilder.AppendLine();
            contentBuilder.AppendLine();
            contentBuilder.AppendLine();
            contentBuilder.AppendLine("   Debtor signature                                                 Bank representative signature");
            contentBuilder.AppendLine();
            contentBuilder.AppendLine();
            contentBuilder.AppendLine("   ----------------                                                        ----------------");
            contentBuilder.AppendLine();
            #endregion Build document content

            var contentStream = new MemoryStream(Encoding.UTF8.GetBytes(contentBuilder.ToString()));

            await _serviceManager.FileService.UploadFile(contentStream, $"{offerId}_{offer.DocumentKey}.txt");
        }

        public async Task<GetOfferResponse> GetById(Guid offerId)
        {
            var offer = await _repositoryManager.OfferRepository.GetById(offerId);
            return offer.Adapt<GetOfferResponse>();
        }

        public async Task<Guid> GetDocumentKey(Guid offerId) => await _repositoryManager.OfferRepository.GetDocumentKey(offerId);

        public async Task SetStatus(Guid offerId, OfferStatus status, string? employee = null)
        {
            if (employee is null)
            {
                await _repositoryManager.OfferRepository.SetStatus(offerId, status);
            }
            else
            {
                await _repositoryManager.OfferRepository.SetStatus(offerId, status, employee);
            }
        }
    }
}
