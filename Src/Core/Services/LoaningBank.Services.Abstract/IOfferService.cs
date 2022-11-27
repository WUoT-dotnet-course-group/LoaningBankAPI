using LoaningBank.CrossCutting.DTO;

namespace LoaningBank.Services.Abstract
{
    public interface IOfferService
    {
        Task Add(AddOfferDTO offer);
        Task<List<GetOfferDTO>> GetAll();
    }
}
