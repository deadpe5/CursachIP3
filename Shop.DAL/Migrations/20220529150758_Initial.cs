using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shop.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenderName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodsStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderStatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    HouseNumber = table.Column<int>(type: "integer", nullable: false),
                    PostalCode = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    GenderId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Manufactured = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Diagonal = table.Column<double>(type: "double precision", nullable: false),
                    CoreCount = table.Column<int>(type: "integer", nullable: false),
                    RAMSize = table.Column<int>(type: "integer", nullable: false),
                    ROMSize = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    GoodsStatusId = table.Column<int>(type: "integer", nullable: false),
                    GoodsTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goods_GoodsStatus_GoodsStatusId",
                        column: x => x.GoodsStatusId,
                        principalTable: "GoodsStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goods_GoodsTypes_GoodsTypeId",
                        column: x => x.GoodsTypeId,
                        principalTable: "GoodsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goods_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderStatusId = table.Column<int>(type: "integer", nullable: false),
                    GoodsId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderName" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "GoodsStatus",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "In store" },
                    { 2, "In stock" },
                    { 3, "Not avaible" }
                });

            migrationBuilder.InsertData(
                table: "GoodsTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Laptop" },
                    { 2, "Desktop" },
                    { 3, "Tablet" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "OrderStatusName" },
                values: new object[,]
                {
                    { 1, "In Progress" },
                    { 2, "Finished" },
                    { 3, "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Moderator" },
                    { 3, "Client" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GenderId", "Name", "PasswordHash", "PasswordSalt", "Phone", "RoleId", "Surname" },
                values: new object[,]
                {
                    { 1, "admin@mail.ua", 3, "Admin", new byte[] { 203, 113, 112, 228, 70, 230, 11, 84, 37, 93, 63, 56, 149, 87, 218, 62, 127, 95, 205, 195, 249, 141, 36, 64, 143, 58, 183, 26, 35, 44, 227, 107, 196, 34, 129, 15, 235, 253, 202, 137, 98, 65, 237, 10, 132, 182, 237, 220, 130, 151, 38, 73, 132, 222, 168, 238, 148, 167, 128, 65, 52, 227, 184, 159 }, new byte[] { 45, 222, 14, 232, 193, 99, 8, 189, 12, 30, 45, 199, 47, 191, 232, 11, 247, 107, 113, 110, 215, 230, 191, 230, 127, 81, 134, 97, 122, 18, 210, 5, 42, 92, 26, 82, 155, 109, 228, 224, 3, 160, 213, 142, 221, 218, 21, 173, 111, 70, 56, 49, 199, 73, 168, 69, 152, 234, 196, 59, 5, 199, 2, 108, 227, 204, 69, 23, 39, 201, 36, 176, 219, 252, 105, 39, 241, 17, 114, 175, 195, 34, 169, 255, 99, 40, 67, 179, 144, 212, 94, 108, 184, 76, 185, 92, 38, 54, 79, 67, 254, 90, 244, 23, 75, 209, 90, 14, 168, 34, 49, 152, 11, 28, 66, 54, 110, 206, 197, 193, 84, 41, 160, 129, 143, 232, 150, 138 }, "0951234567", 1, "Admin" },
                    { 2, "moderator@mail.ua", 3, "Moderator", new byte[] { 203, 113, 112, 228, 70, 230, 11, 84, 37, 93, 63, 56, 149, 87, 218, 62, 127, 95, 205, 195, 249, 141, 36, 64, 143, 58, 183, 26, 35, 44, 227, 107, 196, 34, 129, 15, 235, 253, 202, 137, 98, 65, 237, 10, 132, 182, 237, 220, 130, 151, 38, 73, 132, 222, 168, 238, 148, 167, 128, 65, 52, 227, 184, 159 }, new byte[] { 45, 222, 14, 232, 193, 99, 8, 189, 12, 30, 45, 199, 47, 191, 232, 11, 247, 107, 113, 110, 215, 230, 191, 230, 127, 81, 134, 97, 122, 18, 210, 5, 42, 92, 26, 82, 155, 109, 228, 224, 3, 160, 213, 142, 221, 218, 21, 173, 111, 70, 56, 49, 199, 73, 168, 69, 152, 234, 196, 59, 5, 199, 2, 108, 227, 204, 69, 23, 39, 201, 36, 176, 219, 252, 105, 39, 241, 17, 114, 175, 195, 34, 169, 255, 99, 40, 67, 179, 144, 212, 94, 108, 184, 76, 185, 92, 38, 54, 79, 67, 254, 90, 244, 23, 75, 209, 90, 14, 168, 34, 49, 152, 11, 28, 66, 54, 110, 206, 197, 193, 84, 41, 160, 129, 143, 232, 150, 138 }, "0501234567", 2, "Moderator" },
                    { 3, "client@mail.ua", 3, "Client", new byte[] { 203, 113, 112, 228, 70, 230, 11, 84, 37, 93, 63, 56, 149, 87, 218, 62, 127, 95, 205, 195, 249, 141, 36, 64, 143, 58, 183, 26, 35, 44, 227, 107, 196, 34, 129, 15, 235, 253, 202, 137, 98, 65, 237, 10, 132, 182, 237, 220, 130, 151, 38, 73, 132, 222, 168, 238, 148, 167, 128, 65, 52, 227, 184, 159 }, new byte[] { 45, 222, 14, 232, 193, 99, 8, 189, 12, 30, 45, 199, 47, 191, 232, 11, 247, 107, 113, 110, 215, 230, 191, 230, 127, 81, 134, 97, 122, 18, 210, 5, 42, 92, 26, 82, 155, 109, 228, 224, 3, 160, 213, 142, 221, 218, 21, 173, 111, 70, 56, 49, 199, 73, 168, 69, 152, 234, 196, 59, 5, 199, 2, 108, 227, 204, 69, 23, 39, 201, 36, 176, 219, 252, 105, 39, 241, 17, 114, 175, 195, 34, 169, 255, 99, 40, 67, 179, 144, 212, 94, 108, 184, 76, 185, 92, 38, 54, 79, 67, 254, 90, 244, 23, 75, 209, 90, 14, 168, 34, 49, 152, 11, 28, 66, 54, 110, 206, 197, 193, 84, 41, 160, 129, 143, 232, 150, 138 }, "0671234567", 3, "Client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_GoodsStatusId",
                table: "Goods",
                column: "GoodsStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_GoodsTypeId",
                table: "Goods",
                column: "GoodsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_SupplierId",
                table: "Goods",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GoodsId",
                table: "Orders",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GoodsStatus");

            migrationBuilder.DropTable(
                name: "GoodsTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
