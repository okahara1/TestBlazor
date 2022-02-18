using Microsoft.EntityFrameworkCore;
using TestBlazor.Shared.Models;

namespace TestBlazor.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<T_member> T_member { get; set; }

    }
}
