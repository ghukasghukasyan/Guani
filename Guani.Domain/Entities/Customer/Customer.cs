using Guani.Domain.Entities;
using OnlineShop.Domain.Entities.Order;

namespace Guani.Domain.Entities.Customer
{
    public class Customer : EntityBase
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public virtual List<Order> Orders { get; private set; }

        public Customer(Guid id, string name, string surname, string phoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Orders = new List<Order>();
        }


    }
}
