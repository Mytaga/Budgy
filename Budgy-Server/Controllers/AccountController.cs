using Budgy_Server.Common;
using Budgy_Server.Core.Contracts;
using Budgy_Server.Core.DTOs.Account;
using Budgy_Server.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Budgy_Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(IAccountService accountService, SignInManager<AppUser> signInManager, ILogger<AccountController> logger)
        {
            this.accountService = accountService;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [HttpPost("register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await this.accountService.Register(model);

                if (!result.Succeeded)
                {
                    return Ok(result.Errors);
                }

                return this.StatusCode(201);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.Register, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(LoginDto))]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await this.accountService.Authenticate(model.Email, model.Password);

            try
            {
                if (user == null)
                {
                    return BadRequest(new { message = ExceptionErrors.LoginError });
                }

                var tokenString = this.accountService.GenerateJSONWebToken(user);

                await this.signInManager.SignInAsync(user, true);

                return Ok(new { token = tokenString, userName = user.UserName, id = user.Id, image = user.ImageUrl, firstName = user.FirstName, lastName = user.LastName, email = user.Email });

            }
            catch (Exception ex)
            {
                logger.LogError(Constants.Login, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Produces("application/json")]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await this.signInManager.SignOutAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.Logout, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(UserProfileDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ViewProfile(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            try
            {
                var result = await this.accountService.GetUserProfile(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.ViewProfile, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(UserProfileDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateUserProfileDto model, string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            try
            {
                var result = await this.accountService.UpdateProfile(model, userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.Update, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }
    }
}
