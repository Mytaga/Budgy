namespace Budgy_Server.Core.DTOs.Transaction
{
    public class AllTransactionsDto
    {
        public virtual ICollection<TransactionDto> Transactions { get; set; } = new HashSet<TransactionDto>();
    }
}
