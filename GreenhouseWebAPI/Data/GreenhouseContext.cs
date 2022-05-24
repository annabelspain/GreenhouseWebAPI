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
    }
}
