using Budgy_Server.Common;
using System.ComponentModel.DataAnnotations;

namespace Budgy_Server.Core.DTOs.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage = ModelValidationConstants.AppUserValidation.EmailIsRequiredErrorMsg)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = ModelValidationConstants.AppUserValidation.PasswordIsRequiredErrorMsg)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
