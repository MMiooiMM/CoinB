using CoinB.Data;
using CoinB.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinB.Services
{
    public class TransactionService
    {
        private readonly CoinBDbContext context;

        public TransactionService(CoinBDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Transaction>> GetTransactionsByAccountIdAsync(int accountId, int year, int month)
        {
            return await context.Transactions
                .Where(transaction => transaction.AccountId == accountId)
                .Where(transaction => transaction.Date.Year == year && transaction.Date.Month == month)
                .ToListAsync();
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int id)
        {
            return await context.Transactions.FindAsync(id);
        }

        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            context.Transactions.Add(transaction);
            await context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> UpdateTransactionAsync(Transaction transaction)
        {
            context.Entry(transaction).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return transaction;
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();
            }
        }
    }
}
