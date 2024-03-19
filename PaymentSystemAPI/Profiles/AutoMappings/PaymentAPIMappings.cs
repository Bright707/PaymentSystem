using AutoMapper;
using PaymentSystemAPI.Models;
using PaymentSystemAPI.Models.DTOs;

namespace PaymentSystemAPI.Profiles.AutoMappings
{
    public class PaymentAPIMappings : Profile
    {
        public PaymentAPIMappings()
        {
            CreateMap<Merchant, MerchantDTO>();
            CreateMap<MerchantDTO, Merchant>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
