using Microsoft.EntityFrameworkCore;
using PaymentSystemAPI.Models;

namespace PaymentSystemAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
