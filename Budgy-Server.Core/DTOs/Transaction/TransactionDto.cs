namespace Budgy_Server.Core.DTOs.Transaction
{
    public class TransactionDto
    {
        public string Id { get; set; } = null!;

        public string Amount { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Time { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
