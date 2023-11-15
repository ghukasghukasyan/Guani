using OnlineShop.Domain.Entities;

namespace OnlineShop.DTO
{
    public class CustomerDTO
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public virtual List<Order> Orders { get; private set; }
    }
}
