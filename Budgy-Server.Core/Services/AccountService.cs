using Budgy_Server.Core.Contracts;
using Budgy_Server.Core.DTOs.Account;
using Budgy_Server.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Budgy_Server.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<AppUser> userManager;

        public AccountService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }

        public async Task<AppUser> Authenticate(string email, string password)
        {
            var user = await this.userManager.FindByEmailAsync(email);

            if (user != null && this.userManager.CheckPasswordAsync(user, password).Result)
            {
                return user;
            }

            return null;
        }

        public string GenerateJSONWebToken(AppUser user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var autoSignInkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: this.configuration["JWT:ValidIssuer"],
                audience: this.configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials:
                new SigningCredentials(autoSignInkey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserProfileDto> GetUserProfileAsync(string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            var result = new UserProfileDto
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = user.ImageUrl,
                Email = user.Email,
                Balance = user.Balance.ToString("F2"),
            };

            return result;
        }

        public async Task<IdentityResult> Register(RegisterDto model)
        {
            var user = new AppUser()
            {
                Email = model.Email,
                EmailConfirmed = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<UpdateUserProfileDto> UpdateProfileAsync(UpdateUserProfileDto model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.ImageUrl = model.ImageUrl;

            await this.userManager.UpdateAsync(user);

            return model;
        }
    }
}
