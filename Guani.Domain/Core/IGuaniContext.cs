using Guani.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Entities.Order;

namespace Guani.Domain.Core
{
    public interface IGuaniContext :IGuaniBaseDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
