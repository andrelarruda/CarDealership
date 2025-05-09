using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarDealership.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5965a736-bd6f-4625-b8d3-dfef2161b8af", null, "administrador", "ADMINISTRADOR" },
                    { "6559a392-fcd0-4aec-b134-422a0812c276", null, "vendedor", "VENDEDOR" },
                    { "f652f91e-65e8-485e-9a5f-5af01c89fb36", null, "gerente", "GERENTE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5965a736-bd6f-4625-b8d3-dfef2161b8af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6559a392-fcd0-4aec-b134-422a0812c276");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f652f91e-65e8-485e-9a5f-5af01c89fb36");
        }
    }
}
