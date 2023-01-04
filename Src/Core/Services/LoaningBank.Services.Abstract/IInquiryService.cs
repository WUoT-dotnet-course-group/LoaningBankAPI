using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;

namespace LoaningBank.Services.Abstract
{
    public interface IInquiryService
    {
        Task<CreateInquiryResponse> Add(CreateInquiryRequest request);

        Task<List<GetInquiryDTO>> GetAll();
    }
}
