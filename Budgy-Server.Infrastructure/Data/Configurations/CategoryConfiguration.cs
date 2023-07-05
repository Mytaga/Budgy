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
            });

            builder.HasData(new Category
            {
                Name = "Betting",
                ImageUrl = "",
            });

            builder.HasData(new Category
            {
                Name = "Crypto",
                ImageUrl = "",
            });

            builder.HasData(new Category
            {
                Name = "Investment",
                ImageUrl = "",
            });

            builder.HasData(new Category
            {
                Name = "Orders Refund",
                ImageUrl = "",
            });

            builder.HasData(new Category
            {
                Name = "Tax Refund",
                ImageUrl = "",
            });

            builder.HasData(new Category
            {
                Name = "Kindergarden Refund",
                ImageUrl = "",
            });

            builder.HasData(new Category
            {
                Name = "Other Income",
                ImageUrl = "",
            });
        }
    }
}
