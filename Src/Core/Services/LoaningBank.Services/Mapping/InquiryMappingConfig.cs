using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;
using LoaningBank.CrossCutting.Enums;
using LoaningBank.Domain.Entities;
using Mapster;

namespace LoaningBank.Services.Mapping
{
    public class InquiryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateInquiryRequest, Inquiry>()
                .Map(dest => dest.PersonalData, src => new PersonalData()
                {
                    FirstName = src.PersonalData.FirstName,
                    LastName = src.PersonalData.LastName,
                    BirthDate = src.PersonalData.BirthDate,
                    GovernmentId = src.GovernmentDocument.Number,
                    GovernmentIdType = src.GovernmentDocument.GovernmentIdType,
                    JobType = src.JobDetails.JobType,
                    JobStartDate = src.JobDetails.JobStartDate,
                    JobEndDate = src.JobDetails.JobEndDate,
                });

            config.NewConfig<Inquiry, CreateInquiryResponse>()
                .Map(dest => dest.InquiryId, src => src.ID)
                .Map(dest => dest.CreateDate, src => src.InquireDate);

            config.NewConfig<Inquiry, GetInquiryResponse>()
                .Map(dest => dest.OfferId, src => GetOfferId(src))
                .Map(dest => dest.OfferStatus, src => GetOfferStatus(src))
                .Map(dest => dest.OfferStatusDescription, src => GetOfferStatusDescription(src));

            config.NewConfig<InquirySearch, GetInquiryDetailsResponse>()
                .Map(dest => dest.StatusDescription, src => src.Status.GetValueOrDefault().GetEnumDescription());
        }

        private static Guid? GetOfferId(Inquiry inquiry) => inquiry.Offer switch
        {
            null => null,
            _ => inquiry.Offer.ID,
        };

        private static OfferStatus GetOfferStatus(Inquiry inquiry) => inquiry.Offer switch
        {
            null => OfferStatus.Unknown,
            _ => inquiry.Offer.Status,
        };

        private static string GetOfferStatusDescription(Inquiry inquiry) 
            => EnumExtension.GetEnumDescription(inquiry.Offer switch
            {
                null => OfferStatus.Unknown,
                _ => inquiry.Offer.Status,
            });
    }
}
