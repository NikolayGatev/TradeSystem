using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class FixClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
