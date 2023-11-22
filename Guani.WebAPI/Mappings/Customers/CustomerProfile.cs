using AutoMapper;
using Guani.Domain.Entities.Customer;
using OnlineShop.Domain.Entities;
using OnlineShop.DTO;

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
