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
             .Map(dest => dest.StatusDescription, src => src.Status.GetEnumDescription());
        }
    }
}
