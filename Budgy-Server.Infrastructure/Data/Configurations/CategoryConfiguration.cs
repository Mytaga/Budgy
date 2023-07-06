using Budgy_Server.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgy_Server.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Name = "Salary",
                ImageUrl = "",
                Type = Enums.TransactionType.Income,
            });

            builder.HasData(new Category
            {
                Name = "Betting",
                ImageUrl = "",
                Type = Enums.TransactionType.Income,
            });

            builder.HasData(new Category
            {
                Name = "Crypto",
                ImageUrl = "",
                Type = Enums.TransactionType.Income,
            });

            builder.HasData(new Category
            {
                Name = "Investment",
                ImageUrl = "",
                Type = Enums.TransactionType.Income,
            });

            builder.HasData(new Category
            {
                Name = "Orders Refund",
                ImageUrl = "",
                Type = Enums.TransactionType.Income,
            });

            builder.HasData(new Category
            {
                Name = "Tax Refund",
                ImageUrl = "",
                Type = Enums.TransactionType.Income,
            });

            builder.HasData(new Category
            {
                Name = "Kindergarden Refund",
                ImageUrl = "",
                Type = Enums.TransactionType.Income,
            });

            builder.HasData(new Category
            {
                Name = "Other Income",
                ImageUrl = "",
                Type = Enums.TransactionType.Income,
            });
        }
    }
}
