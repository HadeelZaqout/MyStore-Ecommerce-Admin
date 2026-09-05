using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class updating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0e3d209-7428-4759-b0ef-6ae547a3ae79");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c0e3d209-7428-4759-b0ef-6ae547a3ae79", 0, "a72624ab-0d4e-44d0-abef-3a029b54855e", "hadeel@gmail.com", false, false, null, null, null, null, null, false, "45adb4aa-b7b8-4e3a-bb05-392f40952457", false, "Hadeel" });
        }
    }
}
