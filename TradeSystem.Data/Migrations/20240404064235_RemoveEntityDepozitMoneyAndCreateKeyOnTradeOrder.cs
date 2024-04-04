using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class RemoveEntityDepozitMoneyAndCreateKeyOnTradeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositedMoney");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TradeOrders",
                table: "TradeOrders");

            migrationBuilder.DropIndex(
                name: "IX_TradeOrders_OrderId",
                table: "TradeOrders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TradeOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TradeOrders",
                table: "TradeOrders",
                columns: new[] { "OrderId", "TradeId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e56827c-93fa-44e7-a0c0-239fa9a5dda9", "AQAAAAEAACcQAAAAEFa3rT7rRGXgKkDX7FbaTvA1NZNA2A9rRQeum+r0QXy8Khbnjf++T7IJo8aT1YsxBg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2828cb2-0b12-4a5d-9a17-330b90e05e76", "AQAAAAEAACcQAAAAEPZt6B+ELe4ftE8HCV+K0zDs4A5KKIW++/VZChmGz1vUYHO8dCROTB4YS/yDssB3Yg==" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 149, DateTimeKind.Utc).AddTicks(1324));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 149, DateTimeKind.Utc).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 149, DateTimeKind.Utc).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 136, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 136, DateTimeKind.Utc).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 136, DateTimeKind.Utc).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 136, DateTimeKind.Utc).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 136, DateTimeKind.Utc).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 136, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 136, DateTimeKind.Utc).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 136, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 6, 42, 35, 149, DateTimeKind.Utc).AddTicks(1433));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TradeOrders",
                table: "TradeOrders");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TradeOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TradeOrders",
                table: "TradeOrders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DepositedMoney",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositedMoney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositedMoney_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20dc6f7e-f39b-46da-9bfc-b38745c3d3bc", "AQAAAAEAACcQAAAAEESrzh5u7AhTye3xkEm5yeUKmZ43fWIrsRMcxxigPVLg2aAFVSiVYZy12PsXxCaJaw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ee1001a-6aab-481f-b641-c31a1f04767e", "AQAAAAEAACcQAAAAEBr7SL6f7YjxE19YZ7OyDpekiB5DYlnokgiAy81m6PHqBWwG/P4nA0mdDA/QhXTHIg==" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 144, DateTimeKind.Utc).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 144, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 144, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 131, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 131, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 131, DateTimeKind.Utc).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 131, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 131, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 131, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 131, DateTimeKind.Utc).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 131, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 31, 13, 15, 49, 144, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.CreateIndex(
                name: "IX_TradeOrders_OrderId",
                table: "TradeOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositedMoney_ClientId",
                table: "DepositedMoney",
                column: "ClientId");
        }
    }
}
