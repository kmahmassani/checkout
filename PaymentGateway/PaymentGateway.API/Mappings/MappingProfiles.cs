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

            CreateMap<PaymentSource, PaymentResponseSource>()
                .ForMember(x => x.ExpiryMonth, opt => opt.MapFrom(y => y.Expiry_Month))
                .ForMember(x => x.ExpiryYear, opt => opt.MapFrom(y => y.Expiry_Year));
                

            CreateMap<PaymentRequest, Payment>()
                .BeforeMap((s,d) => {
                    d.Status = PaymentStatus.Captured;
                    d.ProcessedOn = null;
                });                
            
            CreateMap<PaymentRequestSource, PaymentSource>()                
                .ForMember(x => x.Last4, opt => opt.MapFrom(y => y.Number.Right(4)));      
            
            CreateMap<PaymentRequest, BankPaymentRequest>()
                .ForMember(d => d.Cvv, opt => opt.MapFrom(s => s.Source.Cvv))
                .ForMember(d => d.ExpiryMonth, opt => opt.MapFrom(s => s.Source.ExpiryMonth))
                .ForMember(d => d.ExpiryYear, opt => opt.MapFrom(s => s.Source.ExpiryYear))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Source.Name))
                .ForMember(d => d.Number, opt => opt.MapFrom(s => s.Source.Number));                
        }
    }
}
