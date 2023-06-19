using System.ComponentModel.DataAnnotations;

namespace Budgy_Server.Infrastructure.Data.Common
{
    public abstract class BaseModel
    {
        [Key]
        public string Id { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}
