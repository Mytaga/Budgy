using Budgy_Server.Core.Contracts;
using Budgy_Server.Core.DTOs.Transaction;
using Budgy_Server.Infrastructure.Data.Common;
using Budgy_Server.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Budgy_Server.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository repository;

        public TransactionService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Transaction> CreateTransactionAsync(CreateTransactionDto transaction)
        {
            var result = new Transaction
            {
                Amount = transaction.Amount,
                Type = transaction.Type,
                Time = DateTime.UtcNow,
                UserId = transaction.UserId,
                CategoryId = transaction.CategoryId,
                Description = transaction.Description,
            };

            await this.repository.AddAsync(result);
            await this.repository.SaveChangesAsync();
            return result;
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

        public async Task<AllTransactionsDto> GetTrasactionsAsync()
        {
            var result = new AllTransactionsDto();

            var transactions = this.repository
                .AllReadonly<Transaction>()
                .Where(t => t.IsDeleted == false);

            result.Transactions = await transactions
                .Select(t => new TransactionDto
                {
                    Id = t.Id,
                    Amount = t.Amount.ToString("F2"),
                    Type = t.Type.ToString(),
                    Time = t.Time.ToShortTimeString(),
                    UserId = t.UserId,
                    CategoryName = t.Category.Name,
                    Description = t.Description,
                })
                .OrderByDescending(t => t.Time)
                .ToListAsync();

            return result;
        }

        public async Task<ListTransactionCategories> LoadCategoriesAsync(string type)
        {
            var result = new ListTransactionCategories();

            var categories = this.repository.AllReadonly<Category>().Where(c => c.IsDeleted == false);

            if (type == Infrastructure.Data.Enums.TransactionType.Income.ToString())
            {
                categories = categories.Where(c => c.Type == Infrastructure.Data.Enums.TransactionType.Income);
            }
            else
            {
                categories = categories.Where(c => c.Type == Infrastructure.Data.Enums.TransactionType.Expense);
            }

            result.TransactionCategories = await categories
                .Select(c => new TransactionCategory
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .OrderBy(c => c.Name)
                .ToListAsync();

            return result;
        }

        public Task<Transaction> UpdateTransactionAsync(UpdateTransactionDto transaction)
        {
            throw new NotImplementedException();
        }
    }
}
