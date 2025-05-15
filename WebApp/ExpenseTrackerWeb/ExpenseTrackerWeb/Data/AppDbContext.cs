using Microsoft.EntityFrameworkCore;
using ExpenseTrackerWeb.Models;

namespace ExpenseTrackerWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
