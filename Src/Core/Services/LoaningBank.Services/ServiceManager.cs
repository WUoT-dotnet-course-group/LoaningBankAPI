using LoaningBank.Domain.Repositories;
using LoaningBank.Services.Abstract;

namespace LoaningBank.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IInquiryService> _lazyInquiryService;
        private readonly Lazy<IOfferService> _lazyOfferService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyInquiryService = new Lazy<IInquiryService>(() => new InquiryService(repositoryManager));
            _lazyOfferService = new Lazy<IOfferService>(() => new OfferService(repositoryManager));
        }

        public IInquiryService InquiryService => _lazyInquiryService.Value;

        public IOfferService OfferService => _lazyOfferService.Value;
    }
}
