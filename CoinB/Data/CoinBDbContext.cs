using CoinB.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinB.Data
{
    public class CoinBDbContext(DbContextOptions<CoinBDbContext> options) : DbContext(options)
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=coinB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
