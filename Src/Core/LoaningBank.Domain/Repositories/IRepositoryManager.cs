namespace LoaningBank.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IInquiryRepository InquiryRepository { get; }

        IOfferRepository OfferRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
