using System.ComponentModel.DataAnnotations;

namespace Budgy_Server.Infrastructure.Data.Common
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}
