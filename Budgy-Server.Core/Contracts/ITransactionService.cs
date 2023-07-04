using Budgy_Server.Core.DTOs.Transaction;
using Budgy_Server.Infrastructure.Data.Models;

namespace Budgy_Server.Core.Contracts
{
    public interface ITransactionService
    {
        Task<decimal> GetBalanceAsync(string id);

        Task<IEnumerable<TransactionDto>> GetTrasactionsAsync();

        Task<Transaction> GetByIdAsync(string id);

        Task<Transaction> CreateTransactionAsync(CreateTransactionDto transaction);

        Task<Transaction> UpdateTransactionAsync(UpdateTransactionDto transaction);

        Task<Transaction> DeleteTransactionAsync(Transaction transaction);
    }
}
