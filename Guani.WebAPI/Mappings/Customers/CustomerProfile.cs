using AutoMapper;
using Guani.Domain.Entities.Customer;
using Guani.DTO.Customers;

namespace Guani.WebAPI.Mappings.Customers
{
    public class CustomerProfile : Profile
    {

        public CustomerProfile()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();

        }

    }
}
