﻿namespace Budgy_Server.Common
{
    public static class ModelValidationConstants
    {
        public static class AppUserValidation
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 30;
            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 30;
            public const int ImageUrlMaxLength = 300;
            public const int UsernameMinLength = 1;
            public const int UsernameMaxLength = 30;

            public const string EmailIsRequiredErrorMsg = "Email is required!";
            public const string PasswordIsRequiredErrorMsg = "Password is required!";
            public const string UsernameIsRequiredErrorMsg = "Username is required!";
            public const string UsernameMinLengthErrorMsg = "Username length must be at least 1 character!";
            public const string UsernameMaxLengthErrorMsg = "Username length must be no more than 30 characters!";
            public const string FirstNameIsRequiredErrorMsg = "First Name is required!";
            public const string FirstNameMinLengthErrorMsg = "First Name length must be at least 1 characters!";
            public const string FirstNameMaxLengthErrorMsg = "First Name length must be no more than 30 characters!";
            public const string LastNameIsRequiredErrorMsg = "Last Name is required!";
            public const string LastNameMinLengthErrorMsg = "Last Name length must be at least 2 characters!";
            public const string LastNameMaxLengthErrorMsg = "Last Name length must be no more than 30 characters!";
            public const string ImageUrlMaxLengthErrorMsg = "ImageUrl length must be no more than 300 characters!";
        }

        public static class TransactionValidation
        {
            public const int DescriptionMaxLength = 100;
        }

        public static class CategoryValidation
        {
            public const int NameMaxLength = 50;
            public const int ImageUrlMaxLength = 300;
        }
    }
}
