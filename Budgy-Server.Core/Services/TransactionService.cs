using Budgy_Server.Core.Contracts;
using Budgy_Server.Core.DTOs.Transaction;
using Budgy_Server.Infrastructure.Data.Common;
using Budgy_Server.Infrastructure.Data.Models;

namespace Budgy_Server.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository repository;

        public TransactionService(IRepository repository)
        {
            this.repository = repository;
        }

        public Task<Transaction> CreateTransactionAsync(CreateTransactionDto transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<Transaction> DeleteTransactionAsync(Transaction transaction)
        {
            transaction.IsDeleted = true;
            await this.repository.SaveChangesAsync();
            return transaction;
        }

        public async Task<decimal> GetBalanceAsync(string id)
        {
            var user = await this.repository.GetByIdAsync<AppUser>(id);

            return user.Balance;
        }

        public async Task<Transaction> GetByIdAsync(string id)
        {
            return await this.repository.GetByIdAsync<Transaction>(id);
        }

        public Task<IEnumerable<TransactionDto>> GetTrasactionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> UpdateTransactionAsync(UpdateTransactionDto transaction)
        {
            throw new NotImplementedException();
        }
    }
}
