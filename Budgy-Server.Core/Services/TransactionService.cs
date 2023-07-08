using Budgy_Server.Common;
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
        private readonly IAccountService accountService;

        public TransactionService(IRepository repository, IAccountService accountService)
        {
            this.repository = repository;
            this.accountService = accountService;
        }

        public async Task<Transaction> CreateTransactionAsync(CreateTransactionDto model, string userId)
        {
            var result = new Transaction
            {
                Amount = model.Amount,
                Type = model.Type,
                Time = DateTime.UtcNow,
                UserId = model.UserId,
                CategoryId = model.CategoryId,
                Description = model.Description,
            };

            await this.accountService.UpdateProfileBalanceAsync(userId, model.Amount);

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

        public async Task<TransactionDetailsDto> GetTransactionDetailsAsync(string id)
        {
            var transaction = await this.repository.GetByIdAsync<Transaction>(id);

            var result = new TransactionDetailsDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount.ToString("F2"),
                Type = transaction.Type.ToString(),
                Time = transaction.Time.ToShortTimeString(),
                UserId = transaction.UserId,
                CategoryName = transaction.Category.Name,
                Description = transaction.Description,
            };

            return result;
        }

        public async Task<AllTransactionsDto> GetTrasactionsAsync(string userId)
        {
            var result = new AllTransactionsDto();

            var transactions = this.repository
                .AllReadonly<Transaction>()
                .Where(t => t.IsDeleted == false && t.UserId == userId);

            result.Transactions = await transactions
                .Select(t => new TransactionDto
                {
                    Id = t.Id,
                    Amount = t.Amount.ToString("F2"),
                    Time = t.Time.ToShortTimeString(),
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

        public async Task<Transaction> UpdateTransactionAsync(UpdateTransactionDto model, string id, string userId)
        {
            var transaction = await this.repository.GetByIdAsync<Transaction>(id);

            transaction.Amount = model.Amount;
            transaction.Time = DateTime.UtcNow;
            transaction.Type = model.Type;
            transaction.CategoryId = model.CategoryId;
            transaction.Description = model.Description;

            await this.accountService.UpdateProfileBalanceAsync(userId, model.Amount);

            this.repository.Update(transaction);
            await this.repository.SaveChangesAsync();

            return transaction;
        }
    }
}
