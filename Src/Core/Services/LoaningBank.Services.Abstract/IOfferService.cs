using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;

namespace LoaningBank.Services.Abstract
{
    public interface IOfferService
    {
        Task Add(string inquiryId, CreateInquiryRequest inquiryData);
        Task<GetOfferResponse> GetById(string offerId);
    }
}
