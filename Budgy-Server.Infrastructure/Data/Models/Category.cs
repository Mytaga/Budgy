using Budgy_Server.Infrastructure.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Budgy_Server.Infrastructure.Data.Models
{
    public class Category : BaseModel
    {
        public Category()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        [Required]
        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public virtual ICollection<Transaction> Transactions { get; set; } = null!;   
    }
}
