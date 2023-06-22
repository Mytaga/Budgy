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

        Task<UserProfileDto> GetUserProfile(string userId);

        Task<UpdateUserProfileDto> UpdateProfile(UpdateUserProfileDto model, string userId);
    }
}
