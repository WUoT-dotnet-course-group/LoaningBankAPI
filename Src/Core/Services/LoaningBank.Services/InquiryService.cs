using LoaningBank.Domain.Repositories;
using LoaningBank.Services.Abstract;

namespace LoaningBank.Services
{
    internal sealed class InquiryService : IInquiryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public InquiryService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    }
}
