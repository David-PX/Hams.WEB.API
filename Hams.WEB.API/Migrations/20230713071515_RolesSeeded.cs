using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hams.WEB.API.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a09547f5-b7eb-4d9d-b69d-a8abef97097e", "1", "Huesped", "Huesped" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a09547f5-b7eb-4d9d-b69d-a8abef97097e");
        }
    }
}
