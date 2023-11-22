using Guani.Domain.Core;
using Guani.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Order;

namespace OnlineShop.Infrastructure
{
    public class GuaniContext : DbContext, IGuaniContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public GuaniContext(DbContextOptions<GuaniContext> options) : base(options) { }

    }
}
