using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budgy_Server.Infrastructure.Migrations
{
    public partial class IncomeCategoriesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "055a276d-842e-4c00-88bc-eec1b4e02f59", "", false, "Kindergarden Refund" },
                    { "081eda72-574c-4299-90da-07a56b41d088", "", false, "Salary" },
                    { "10681c64-d149-4854-90ce-6c8e8b9ef954", "", false, "Other Income" },
                    { "1ea463f8-4537-4ba8-a75d-4577e1dd41fb", "", false, "Crypto" },
                    { "28b56a94-0677-487f-96fb-5bcba10bbb31", "", false, "Tax Refund" },
                    { "43bb8cb7-32ed-4b96-a637-bb65699c54d2", "", false, "Investment" },
                    { "9fd5f9f4-ef0a-48fa-98b2-79b4174d459a", "", false, "Betting" },
                    { "d2fbf2c4-77da-4041-a296-ff70824d1273", "", false, "Orders Refund" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "055a276d-842e-4c00-88bc-eec1b4e02f59");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "081eda72-574c-4299-90da-07a56b41d088");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "10681c64-d149-4854-90ce-6c8e8b9ef954");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1ea463f8-4537-4ba8-a75d-4577e1dd41fb");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "28b56a94-0677-487f-96fb-5bcba10bbb31");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "43bb8cb7-32ed-4b96-a637-bb65699c54d2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9fd5f9f4-ef0a-48fa-98b2-79b4174d459a");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d2fbf2c4-77da-4041-a296-ff70824d1273");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Transactions");
        }
    }
}
