using Budgy_Server.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static Budgy_Server.Common.ModelValidationConstants;

namespace Budgy_Server.Core.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        [Required(ErrorMessage = TransactionValidation.AmountIsRequiredErrorMsg)]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = TransactionValidation.TypeIsRequiredErrorMsg)]
        public TransactionType Type { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public string CategoryId { get; set; } = null!;

        [MinLength(TransactionValidation.DescriptionMinLength, ErrorMessage = TransactionValidation.DescriptionMinLengthErrorMsg)]
        [MaxLength(TransactionValidation.DescriptionMaxLength, ErrorMessage = TransactionValidation.DescriptionMinLengthErrorMsg)]
        public string Description { get; set; } = null!;
    }
}
