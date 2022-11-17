using LoaningBank.Domain.Repositories;

namespace LoaningBank.DataPersistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IInquiryRepository> _inquiryRepository;
        private readonly Lazy<IOfferRepository> _offerRepository;
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _inquiryRepository = new Lazy<IInquiryRepository>(() => new InquiryRepository(dbContext));
            _offerRepository = new Lazy<IOfferRepository>(() => new OfferRepository(dbContext));
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IInquiryRepository InquiryRepository => _inquiryRepository.Value;

        public IOfferRepository OfferRepository => _offerRepository.Value;

        public IUnitOfWork UnitOfWork => _unitOfWork.Value;
    }
}
