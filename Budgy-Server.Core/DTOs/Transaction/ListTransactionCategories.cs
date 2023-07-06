namespace Budgy_Server.Core.DTOs.Transaction
{
    public class ListTransactionCategories
    {
        public virtual ICollection<TransactionCategory> TransactionCategories { get; set; } = new HashSet<TransactionCategory>();
    }
}
