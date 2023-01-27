using Microsoft.EntityFrameworkCore;
using Trendy.Models;
namespace Trendy.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<HairCutBooking> Bookings { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
            
        }
    }
}
