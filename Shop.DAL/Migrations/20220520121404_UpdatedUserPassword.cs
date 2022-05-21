using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DAL.Migrations
{
    public partial class UpdatedUserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 54, 176, 198, 137, 43, 238, 175, 10, 216, 224, 158, 72, 57, 1, 53, 158, 10, 191, 19, 250, 173, 27, 180, 107, 193, 254, 129, 245, 5, 202, 169, 188, 151, 227, 183, 239, 151, 249, 68, 244, 187, 115, 69, 37, 77, 28, 81, 142, 122, 135, 167, 158, 139, 66, 219, 148, 83, 246, 252, 167, 98, 55, 245, 211 }, new byte[] { 224, 50, 49, 61, 30, 28, 86, 111, 199, 182, 236, 85, 48, 36, 55, 179, 224, 134, 167, 115, 215, 40, 197, 9, 169, 255, 61, 181, 162, 165, 61, 197, 118, 26, 216, 204, 238, 25, 182, 188, 240, 190, 225, 34, 82, 104, 46, 115, 78, 80, 78, 160, 243, 191, 186, 235, 33, 17, 136, 76, 5, 113, 86, 58, 40, 39, 173, 218, 182, 109, 180, 86, 45, 14, 55, 134, 61, 54, 11, 164, 192, 179, 138, 222, 56, 165, 131, 191, 37, 149, 71, 46, 65, 248, 207, 117, 198, 1, 142, 94, 83, 246, 108, 236, 252, 52, 88, 193, 77, 236, 101, 12, 94, 217, 14, 202, 181, 19, 237, 128, 175, 200, 173, 234, 60, 149, 166, 71 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "admin");
        }
    }
}
