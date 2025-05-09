using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }

        public DbSet<SearchHistoryEntity> SearchHistories { get; set; }
    }
}
