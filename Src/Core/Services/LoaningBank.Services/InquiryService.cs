using LoaningBank.CrossCutting.DTO;
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

        public async Task Add(AddInquiryDTO inquiry)
        {
            var inquiryToAdd = inquiry.Adapt<Inquiry>();

            await _repositoryManager.InquiryRepository.Add(inquiryToAdd);
        }

        public async Task<IEnumerable<Guid>> GetAllIds()
        {
            var inquiries = await _repositoryManager.InquiryRepository.GetAll();
            return inquiries.Select(x => x.ID);
        }
    }
}
