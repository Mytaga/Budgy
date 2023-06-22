namespace Budgy_Server.Core.DTOs.Account
{
    public class UserProfileDto
    {
        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        
        public string Email { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
