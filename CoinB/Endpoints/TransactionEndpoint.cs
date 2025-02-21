using CoinB.Data.Models;
using CoinB.Models.Transaction;
using CoinB.Services;

namespace CoinB.Endpoints
{
    public static class TransactionEndpoint
    {
        public static void MapTransactionEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/transactions", GetAllTransactions)
            .WithName(nameof(GetAllTransactions));

            routes.MapGet("/transaction/{id}", GetTransactionById)
            .WithName(nameof(GetTransactionById));

            routes.MapPost("/transaction", AddTransaction)
            .WithName(nameof(AddTransaction));

            routes.MapPut("/transaction/{id}", UpdateTransaction)
            .WithName(nameof(UpdateTransaction));

            routes.MapDelete("/transaction/{id}", DeleteTransaction)
            .WithName(nameof(DeleteTransaction));
        }

        private static async Task<List<TransactionResponseDto>> GetAllTransactions(TransactionService service)
        {
            var list = await service.GetAllTransactionsAsync();
            return list.Select(data => new TransactionResponseDto
            {
                TransactionId = data.TransactionId,
                Amount = data.Amount,
                Date = data.Date,
                Description = data.Description,
                CategoryId = data.CategoryId,
                AccountId = data.AccountId
            }).ToList();
        }

        private static async Task<TransactionResponseDto> GetTransactionById(int id, TransactionService service)
        {
            var data = await service.GetTransactionByIdAsync(id) ?? throw new Exception("Transaction not found");
            return new TransactionResponseDto
            {
                TransactionId = data.TransactionId,
                Amount = data.Amount,
                Date = data.Date,
                Description = data.Description,
                CategoryId = data.CategoryId,
                AccountId = data.AccountId
            };
        }

        private static async Task<TransactionResponseDto> AddTransaction(AddTransactionRequestDto data, TransactionService service)
        {
            var transaction = new Transaction
            {
                Amount = data.Amount,
                Date = data.Date,
                Description = data.Description,
                CategoryId = data.CategoryId,
                AccountId = data.AccountId
            };

            await service.AddTransactionAsync(transaction);

            return new TransactionResponseDto
            {
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                CategoryId = transaction.CategoryId,
                AccountId = transaction.AccountId
            };
        }

        private static async Task<TransactionResponseDto> UpdateTransaction(int id, UpdateTransactionRequestDto data, TransactionService service)
        {
            if (id != data.TransactionId)
            {
                throw new Exception("Id does not match");
            }

            var transaction = await service.GetTransactionByIdAsync(id) ?? throw new Exception("Transaction not found");

            transaction.Amount = data.Amount;
            transaction.Date = data.Date;
            transaction.Description = data.Description;
            transaction.CategoryId = data.CategoryId;
            transaction.AccountId = data.AccountId;

            await service.UpdateTransactionAsync(transaction);

            return new TransactionResponseDto
            {
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description,
                CategoryId = transaction.CategoryId,
                AccountId = transaction.AccountId
            };
        }

        private static async Task DeleteTransaction(int id, TransactionService service)
        {
            await service.DeleteTransactionAsync(id);
        }
    }
}
