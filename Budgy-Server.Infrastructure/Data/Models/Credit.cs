using Budgy_Server.Infrastructure.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Budgy_Server.Infrastructure.Data.Models
{
    public class Credit : BaseModel
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal MonthlyPaymennt { get; set; }

        [Required]
        public DateOnly DueDate { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual AppUser User { get; set; } = null!;
    }
}
