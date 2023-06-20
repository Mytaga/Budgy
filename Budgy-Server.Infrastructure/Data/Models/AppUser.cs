using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Budgy_Server.Common.ModelValidationConstants;


namespace Budgy_Server.Infrastructure.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Transactions = new HashSet<Transaction>();
            this.Credits = new HashSet<Credit>();
        }

        [Required]
        [MaxLength(AppUserValidation.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(AppUserValidation.LasttNameMaxLength)]
        public string LastName { get; set; } = null!;

        [MaxLength(AppUserValidation.ImageUrlMaxLength)]
        public string? ImageUrl { get; set; } 

        [Required]
        public decimal Balance { get; set; } = 0;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Transaction> Transactions { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }
    }
}
