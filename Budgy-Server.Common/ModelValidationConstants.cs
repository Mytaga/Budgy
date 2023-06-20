namespace Budgy_Server.Common
{
    public static class ModelValidationConstants
    {
        public static class AppUserValidation
        {
            public const int FirstNameMaxLength = 30;
            public const int LasttNameMaxLength = 30;
            public const int ImageUrlMaxLength = 300;
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
