using CoinB.Data.Models;
using CoinB.Models.Account;
using CoinB.Services;

namespace CoinB.Endpoints
{
    public static class AccountEndpoint
    {
        public static void MapAccountEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/accounts", GetAllAccounts)
            .WithName(nameof(GetAllAccounts));

            routes.MapGet("/account/{id}", GetAccountById)
            .WithName(nameof(GetAccountById));

            routes.MapPost("/account", AddAccount)
            .WithName(nameof(AddAccount));

            routes.MapPut("/account/{id}", UpdateAccount)
            .WithName(nameof(UpdateAccount));

            routes.MapDelete("/account/{id}", DeleteAccount)
            .WithName(nameof(DeleteAccount));
        }

        private static async Task<List<AccountResponseDto>> GetAllAccounts(AccountService service)
        {
            var list = await service.GetAllAccountsAsync();
            return list.Select(data => new AccountResponseDto
            {
                AccountId = data.AccountId,
                AccountName = data.AccountName
            }).ToList();
        }

        private static async Task<AccountResponseDto> GetAccountById(int id, AccountService service)
        {
            var data = await service.GetAccountByIdAsync(id) ?? throw new Exception("Account not found");
            return new AccountResponseDto
            {
                AccountId = data.AccountId,
                AccountName = data.AccountName
            };
        }

        private static async Task<AccountResponseDto> AddAccount(AddAccountRequestDto data, AccountService service)
        {
            var account = new Account
            {
                AccountName = data.AccountName
            };

            await service.AddAccountAsync(account);

            return new AccountResponseDto
            {
                AccountId = account.AccountId,
                AccountName = account.AccountName
            };
        }

        private static async Task<AccountResponseDto> UpdateAccount(int id, UpdateAccountRequestDto data, AccountService service)
        {
            var account = await service.GetAccountByIdAsync(id) ?? throw new Exception("Account not found");

            account.AccountName = data.AccountName;

            await service.UpdateAccountAsync(account);

            return new AccountResponseDto
            {
                AccountId = account.AccountId,
                AccountName = account.AccountName
            };
        }

        private static async Task DeleteAccount(int id, AccountService service)
        {
            await service.DeleteAccountAsync(id);
        }
    }
}
