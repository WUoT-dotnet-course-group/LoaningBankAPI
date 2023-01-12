using Azure.Storage.Blobs;
using LoaningBank.Domain.Repositories;
using LoaningBank.Services.Abstract;

namespace LoaningBank.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IInquiryService> _lazyInquiryService;
        private readonly Lazy<IOfferService> _lazyOfferService;
        private readonly Lazy<IFileService> _lazyFileService;

        public ServiceManager(IRepositoryManager repositoryManager, BlobServiceClient blobService, IServicesConfiguration configuration)
        {
            _lazyInquiryService = new Lazy<IInquiryService>(() => new InquiryService(repositoryManager));
            _lazyOfferService = new Lazy<IOfferService>(() => new OfferService(repositoryManager, this));
            _lazyFileService = new Lazy<IFileService>(() => new FileService(blobService.GetBlobContainerClient(configuration.BlobContainerName)));
        }

        public IInquiryService InquiryService => _lazyInquiryService.Value;

        public IOfferService OfferService => _lazyOfferService.Value;

        public IFileService FileService => _lazyFileService.Value;
    }
}
