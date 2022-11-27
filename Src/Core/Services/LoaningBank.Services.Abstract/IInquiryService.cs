using LoaningBank.CrossCutting.DTO;

namespace LoaningBank.Services.Abstract
{
    public interface IInquiryService
    {
        Task Add(AddInquiryDTO inquiry);

        Task<List<GetInquiryDTO>> GetAll();
    }
}
