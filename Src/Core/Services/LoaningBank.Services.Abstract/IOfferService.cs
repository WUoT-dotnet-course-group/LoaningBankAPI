using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;
using LoaningBank.CrossCutting.Enums;

namespace LoaningBank.Services.Abstract
{
    public interface IOfferService
    {
        Task<Guid> Add(string inquiryId, CreateInquiryRequest inquiryData);
        Task<GetOfferResponse> GetById(Guid offerId);
        Task<Guid> GetDocumentKey(Guid offerId);
        Task GenerateDocument(Guid offerId);
        Task SetStatus(Guid offerId, OfferStatus status, string? employee = null);
    }
}
