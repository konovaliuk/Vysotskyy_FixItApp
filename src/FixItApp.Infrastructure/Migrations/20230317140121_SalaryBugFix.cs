using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FixItApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalaryBugFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2bf2575a-295a-40b4-8a7c-d24239df8056");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "79bc8637-916b-4080-86d0-a86dbdb19595");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f84d91ea-2987-4651-a3fa-dad17704a59e");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Applications",
                type: "decimal(15,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "5a8944d9-636e-4a1b-a879-71fae3665bbc", "Master" },
                    { "6b7cef46-e804-4ad5-9d5a-bcb3219eb1ba", "Customer" },
                    { "e4954596-88a6-499f-a948-69df85b34a55", "Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5a8944d9-636e-4a1b-a879-71fae3665bbc");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6b7cef46-e804-4ad5-9d5a-bcb3219eb1ba");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e4954596-88a6-499f-a948-69df85b34a55");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Applications",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,2)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2bf2575a-295a-40b4-8a7c-d24239df8056", "Master" },
                    { "79bc8637-916b-4080-86d0-a86dbdb19595", "Manager" },
                    { "f84d91ea-2987-4651-a3fa-dad17704a59e", "Customer" }
                });
        }
    }
}
