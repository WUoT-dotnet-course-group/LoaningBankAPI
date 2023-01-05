using LoaningBank.CrossCutting.DTO;

namespace LoaningBank.Services.Abstract
{
    public interface IOfferService
    {
        Task Add(string inquiryId);
        Task<GetOfferResponse> GetById(string offerId);
    }
}
