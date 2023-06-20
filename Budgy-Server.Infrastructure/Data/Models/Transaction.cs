using Budgy_Server.Infrastructure.Data.Common;
using Budgy_Server.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Budgy_Server.Common.ModelValidationConstants;

namespace Budgy_Server.Infrastructure.Data.Models
{
    public class Transaction : BaseModel
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public static DateTime Time => DateTime.UtcNow;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual AppUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public string CategoryId { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;

        [MaxLength(TransactionValidation.DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}
