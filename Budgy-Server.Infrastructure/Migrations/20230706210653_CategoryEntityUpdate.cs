using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budgy_Server.Infrastructure.Migrations
{
    public partial class CategoryEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "IsDeleted", "Name", "Type" },
                values: new object[,]
                {
                    { "41029f58-4c3e-4b43-a337-0c15775dab65", "", false, "Salary", 0 },
                    { "532396af-9183-481c-98e9-46aacbb4ff29", "", false, "Kindergarden Refund", 0 },
                    { "552bd333-c083-49f4-82d4-56fea272b069", "", false, "Tax Refund", 0 },
                    { "60649386-c055-44b4-b125-e843ace82c23", "", false, "Betting", 0 },
                    { "765e635c-3540-410a-b6ab-72035a2ee845", "", false, "Orders Refund", 0 },
                    { "913dd5b6-fbc1-41c4-a460-a833ee9357b6", "", false, "Investment", 0 },
                    { "b1994ab3-789c-4b99-97f7-54d2f8ca6656", "", false, "Other Income", 0 },
                    { "f1d7c6a2-14dd-43dc-b65e-6ed3c1175c91", "", false, "Crypto", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "41029f58-4c3e-4b43-a337-0c15775dab65");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "532396af-9183-481c-98e9-46aacbb4ff29");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "552bd333-c083-49f4-82d4-56fea272b069");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "60649386-c055-44b4-b125-e843ace82c23");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "765e635c-3540-410a-b6ab-72035a2ee845");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "913dd5b6-fbc1-41c4-a460-a833ee9357b6");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "b1994ab3-789c-4b99-97f7-54d2f8ca6656");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f1d7c6a2-14dd-43dc-b65e-6ed3c1175c91");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Categories");

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
    }
}
