using GreenhouseWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenhouseWebAPI.Data
{
    public class GreenhouseContext : DbContext
    {
        public GreenhouseContext(DbContextOptions<GreenhouseContext> options) : base(options)
        {

        }
        public DbSet<GreenhouseItem> GreenhouseItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
