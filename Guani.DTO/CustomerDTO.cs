using OnlineShop.Domain.Entities;

namespace OnlineShop.DTO
{
    public class CustomerDTO
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string Surname { get;  set; }
        public string PhoneNumber { get;  set; }
    }
}
