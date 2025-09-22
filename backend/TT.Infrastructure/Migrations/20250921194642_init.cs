using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditCreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AuditCreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AuditCreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AuditCreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
