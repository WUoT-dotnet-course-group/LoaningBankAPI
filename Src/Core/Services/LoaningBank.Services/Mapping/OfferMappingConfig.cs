using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.Enums;
using LoaningBank.Domain.Entities;
using Mapster;

namespace LoaningBank.Services.Mapping
{
    public class OfferMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Offer, GetOfferResponse>()
             .Map(dest => dest.StatusDescription, src => src.Status.GetEnumDescription())
             .Map(dest => dest.DocumentLink, src => GetDocumentLink(src))
             .Map(dest => dest.DocumentLinkValidDate, src => GetDocumentValidDate(src));
        }

        private static string? GetDocumentLink(Offer src) 
            => (src.DocumentLinkValidDate - DateTime.Now).TotalMilliseconds switch
            {
                > 0 => @$"https://loaning-bank-api.azurewebsites.net/api/offers/{src.ID}/document/{src.DocumentKey}",
                _ => null,
            };

        private static DateTime? GetDocumentValidDate(Offer src)
            => (src.DocumentLinkValidDate - DateTime.Now).TotalMilliseconds switch
            {
                > 0 => src.DocumentLinkValidDate,
                _ => null,
            };
    }
}
