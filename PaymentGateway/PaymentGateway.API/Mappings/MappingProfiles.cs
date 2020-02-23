using AutoMapper;
using PaymentGateway.API.Extensions;
using PaymentGateway.Domain.HttpModels;
using PaymentGateway.Domain.POCOs;

namespace PaymentGateway.API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Payment, PaymentResponse>();

            CreateMap<PaymentRequest, Payment>()
                .BeforeMap((s,d) => {
                    d.Status = PaymentStatus.Captured;
                    d.ProcessedOn = null;
                });                
            
            CreateMap<PaymentRequestSource, PaymentSource>()                
                .ForMember(x => x.Last4, opt => opt.MapFrom(y => y.Number.Right(4)));                               
        }
    }
}
