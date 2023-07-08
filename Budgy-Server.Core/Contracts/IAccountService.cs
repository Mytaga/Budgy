using Budgy_Server.Core.DTOs.Account;
using Budgy_Server.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Budgy_Server.Core.Contracts
{
    public interface IAccountService
    {
        Task<AppUser> Authenticate(string email, string password);

        string GenerateJSONWebToken(AppUser user);

        Task<IdentityResult> Register(RegisterDto model);

        Task<UserProfileDto> GetUserProfileAsync(string userId);

        Task<UpdateUserProfileDto> UpdateProfileAsync(UpdateUserProfileDto model, string userId);

        Task<decimal> UpdateProfileBalanceAsync(string userId, decimal amount);

        Task<bool> ExistByIdAsync(string userId);
    }
}
