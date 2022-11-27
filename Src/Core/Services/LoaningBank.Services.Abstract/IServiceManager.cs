namespace LoaningBank.Services.Abstract
{
    public interface IServiceManager
    {
        IInquiryService InquiryService { get; }

        IOfferService OfferService { get; }
    }
}
