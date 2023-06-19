using Budgy_Server.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        public string? ImageUrl { get; set; } 

        [Required]
        public decimal Balance { get; set; } = 0;

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<Credit> Credits { get; set; }
    }
}
