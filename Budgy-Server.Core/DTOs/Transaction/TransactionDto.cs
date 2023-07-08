using Budgy_Server.Infrastructure.Data.Enums;

namespace Budgy_Server.Core.DTOs.Transaction
{
    public class TransactionDto
    {
        public string Id { get; set; } = null!;

        public string Amount { get; set; } = null!;

        public string Time { get; set; } = null!;
    }
}
