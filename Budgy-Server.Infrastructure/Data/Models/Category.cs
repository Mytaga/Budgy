using Budgy_Server.Infrastructure.Data.Common;
using System.ComponentModel.DataAnnotations;
using static Budgy_Server.Common.ModelValidationConstants;

namespace Budgy_Server.Infrastructure.Data.Models
{
    public class Category : BaseModel
    {
        public Category()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        [Required]
        [MaxLength(CategoryValidation.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(CategoryValidation.ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public virtual ICollection<Transaction> Transactions { get; set; } = null!;   
    }
}
