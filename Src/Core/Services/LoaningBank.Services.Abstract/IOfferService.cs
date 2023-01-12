using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;

namespace LoaningBank.Services.Abstract
{
    public interface IOfferService
    {
        Task<Guid> Add(string inquiryId, CreateInquiryRequest inquiryData);
        Task<GetOfferResponse> GetById(Guid offerId);
        Task<Guid> GetDocumentKey(Guid offerId);
        Task GenerateDocument(Guid offerId);
    }
}
