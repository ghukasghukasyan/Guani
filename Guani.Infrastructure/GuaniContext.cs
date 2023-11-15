using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using System;
using System.Reflection;

namespace OnlineShop.Infrastructure
{
    public class GuaniContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public GuaniContext(DbContextOptions<GuaniContext> options) : base(options) { }

    }
}
