using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;
using LoaningBank.Domain.Entities;
using LoaningBank.Domain.Repositories;
using LoaningBank.Services.Abstract;
using Mapster;

namespace LoaningBank.Services
{
    internal sealed class InquiryService : IInquiryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public InquiryService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<CreateInquiryResponse> Add(CreateInquiryRequest request)
        {
            var inquiryToAdd = request.Adapt<Inquiry>();

            var inqiry = await _repositoryManager.InquiryRepository.Add(inquiryToAdd);

            return inqiry.Adapt<CreateInquiryResponse>();
        }

        public async Task<List<GetInquiryDTO>> GetAll()
        {
            var inquiries = await _repositoryManager.InquiryRepository.GetAll();

            return inquiries.Adapt<List<GetInquiryDTO>>();
        }
    }
}
