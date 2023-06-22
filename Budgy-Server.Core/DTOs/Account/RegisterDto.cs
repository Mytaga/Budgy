using System.ComponentModel.DataAnnotations;
using static Budgy_Server.Common.ModelValidationConstants;

namespace Budgy_Server.Core.DTOs.Account
{
    public class RegisterDto
    {
        [Required(ErrorMessage = AppUserValidation.EmailIsRequiredErrorMsg)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = AppUserValidation.PasswordIsRequiredErrorMsg)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = AppUserValidation.UsernameIsRequiredErrorMsg)]
        [MinLength(AppUserValidation.UsernameMinLength, ErrorMessage = AppUserValidation.UsernameMinLengthErrorMsg)]
        [MaxLength(AppUserValidation.UsernameMaxLength, ErrorMessage = AppUserValidation.UsernameMaxLengthErrorMsg)]
        public string UserName { get; set; } = null!;


        [Required(ErrorMessage = AppUserValidation.FirstNameIsRequiredErrorMsg)]
        [MinLength(AppUserValidation.FirstNameMinLength, ErrorMessage = AppUserValidation.FirstNameMinLengthErrorMsg)]
        [MaxLength(AppUserValidation.FirstNameMaxLength, ErrorMessage = AppUserValidation.FirstNameMaxLengthErrorMsg)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = AppUserValidation.LastNameIsRequiredErrorMsg)]
        [MinLength(AppUserValidation.LastNameMinLength, ErrorMessage = AppUserValidation.LastNameMinLengthErrorMsg)]
        [MaxLength(AppUserValidation.LastNameMaxLength, ErrorMessage = AppUserValidation.LastNameMaxLengthErrorMsg)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
    }
}
