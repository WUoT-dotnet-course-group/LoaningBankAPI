using LoaningBank.Domain.Repositories;
using LoaningBank.Services.Abstract;

namespace LoaningBank.Services
{
    internal sealed class InquiryService : IInquiryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public InquiryService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<Guid>> GetAllIds()
        {
            var inquiries = await _repositoryManager.InquiryRepository.GetAll();
            return inquiries.Select(x => x.ID);
        }
    }
}
