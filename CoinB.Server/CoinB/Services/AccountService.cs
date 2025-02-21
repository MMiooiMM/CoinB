using CoinB.Data;
using CoinB.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinB.Services
{
    public class AccountService(CoinBDbContext context)
    {
        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            return await context.Accounts.FindAsync(id);
        }

        public async Task<Account> AddAccountAsync(Account account)
        {
            context.Accounts.Add(account);
            await context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            context.Entry(account).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await context.Accounts.FindAsync(id);
            if (account != null)
            {
                context.Accounts.Remove(account);
                await context.SaveChangesAsync();
            }
        }
    }
}
