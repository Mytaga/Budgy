﻿using Budgy_Server.Core.DTOs.Transaction;
using Budgy_Server.Infrastructure.Data.Models;

namespace Budgy_Server.Core.Contracts
{
    public interface ITransactionService
    {
        Task<decimal> GetBalanceAsync(string id);

        Task<AllTransactionsDto> GetTrasactionsAsync(string userId);

        Task<Transaction> GetByIdAsync(string id);

        Task<Transaction> CreateTransactionAsync(CreateTransactionDto model, string userId);

        Task<Transaction> UpdateTransactionAsync(UpdateTransactionDto model, string id, string userId);

        Task<Transaction> DeleteTransactionAsync(string id);

        Task<ListTransactionCategories> LoadCategoriesAsync(string type);

        Task<TransactionDetailsDto> GetTransactionDetailsAsync(string id);

        Task<bool> ExistByIdAsync(string id);
    }
}
