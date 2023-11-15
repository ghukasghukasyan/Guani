using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;

namespace Guani.Domain.Core
{
    public interface IGuaniContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
