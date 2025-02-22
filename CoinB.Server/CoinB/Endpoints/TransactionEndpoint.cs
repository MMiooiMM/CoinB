using CoinB.Data.Models;
using CoinB.Models.Transaction;
using CoinB.Services;

namespace CoinB.Endpoints
{
    public static class TransactionEndpoint
    {
        public static void MapTransactionEndpoints(this IEndpointRouteBuilder routes)
        {            
            routes.MapGet("/account/{accountId}/transactions", GetTransactionsByAccount)
            .WithName(nameof(GetTransactionsByAccount));

            routes.MapGet("/account/{accountId}/transaction/{id}", GetTransactionById)
            .WithName(nameof(GetTransactionById));

            routes.MapPost("/account/{accountId}/transaction", AddTransaction)
            .WithName(nameof(AddTransaction));

            routes.MapPut("/account/{accountId}/transaction/{id}", UpdateTransaction)
            .WithName(nameof(UpdateTransaction));

            routes.MapDelete("/account/{accountId}/transaction/{id}", DeleteTransaction)
            .WithName(nameof(DeleteTransaction));
        }

        private static async Task<List<TransactionResponseDto>> GetTransactionsByAccount(int accountId, [AsParameters] GetTransactionRequestDto query, TransactionService service)
        {
            var list = await service.GetTransactionsByAccountIdAsync(accountId, query.Year, query.Month);
            return list.Select(data => new TransactionResponseDto
            {
                TransactionId = data.TransactionId,
                Amount = data.Amount,
                Date = data.Date,
                Description = data.Description,
                CategoryId = data.CategoryId,
            }).ToList();
        }

        private static async Task<TransactionResponseDto> GetTransactionById(int accountId, int id, TransactionService service)
        {
            var transaction = await service.GetTransactionByIdAsync(id) ?? throw new Exception("Transaction not found");

            if (transaction.AccountId != accountId)
            {
                throw new Exception("Account ID does not match the transaction's account ID");
            }

            return new TransactionResponseDto
            {
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                CategoryId = transaction.CategoryId
            };
        }

        private static async Task<TransactionResponseDto> AddTransaction(int accountId, AddTransactionRequestDto data, TransactionService service)
        {
            var transaction = new Transaction
            {
                Amount = data.Amount,
                Date = data.Date,
                Description = data.Description,
                CategoryId = data.CategoryId,
                AccountId = accountId
            };

            await service.AddTransactionAsync(transaction);

            return new TransactionResponseDto
            {
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                CategoryId = transaction.CategoryId
            };
        }

        private static async Task<TransactionResponseDto> UpdateTransaction(int accountId, int id, UpdateTransactionRequestDto data, TransactionService service)
        {
            var transaction = await service.GetTransactionByIdAsync(id) ?? throw new Exception("Transaction not found");

            transaction.Amount = data.Amount;
            transaction.Date = data.Date;
            transaction.Description = data.Description;
            transaction.CategoryId = data.CategoryId;

            await service.UpdateTransactionAsync(transaction);

            return new TransactionResponseDto
            {
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                CategoryId = transaction.CategoryId
            };
        }

        private static async Task DeleteTransaction(int accountId, int id, TransactionService service)
        {
            var transaction = await service.GetTransactionByIdAsync(id) ?? throw new Exception("Transaction not found");

            if (transaction.AccountId != accountId)
            {
                throw new Exception("Account ID does not match the transaction's account ID");
            }

            await service.DeleteTransactionAsync(id);
        }
    }
}
