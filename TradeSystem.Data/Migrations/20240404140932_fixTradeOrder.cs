using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class fixTradeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TradeOrders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22c22003-f9ad-4d93-b43c-6a62dcefcb7a", "AQAAAAEAACcQAAAAEGpZBQdACcannkWvSSo99OUT14/i8oxSoq0CBvZqv2YMrFNaMSNJCAdarAkJFvVIng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4abca6b7-ff2a-4467-a72e-686657262830", "AQAAAAEAACcQAAAAEJW7IlgAuZ+ldhOm2lEuSJ/UXyf45clc6KWORkZXxZv0u4HGE2bWyUHVu21OuyvhHA==" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 76, DateTimeKind.Utc).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 76, DateTimeKind.Utc).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 76, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 64, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 64, DateTimeKind.Utc).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 64, DateTimeKind.Utc).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 64, DateTimeKind.Utc).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 64, DateTimeKind.Utc).AddTicks(359));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 64, DateTimeKind.Utc).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 64, DateTimeKind.Utc).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 64, DateTimeKind.Utc).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 14, 9, 32, 76, DateTimeKind.Utc).AddTicks(4244));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TradeOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33756269-50a8-4040-99d3-b3ef3db5a2b6", "AQAAAAEAACcQAAAAEGNbgbCQxLSxGfM1/AWIFL0Kmy2qt02pXSYK3v1UTubI108f7f7HqwU6Y96rdFkHXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a971148c-1283-4a3b-85ab-ee55d642bbf3", "AQAAAAEAACcQAAAAEDGkj7nMklL4jLoIsELiZc51dM+GyIRwmVu/+adHO037VusI9neJWuV6Lxbu9/RaQA==" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 654, DateTimeKind.Utc).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 654, DateTimeKind.Utc).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 654, DateTimeKind.Utc).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 641, DateTimeKind.Utc).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 641, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 641, DateTimeKind.Utc).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 641, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 641, DateTimeKind.Utc).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 641, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 641, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 641, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 4, 13, 49, 11, 654, DateTimeKind.Utc).AddTicks(537));
        }
    }
}
