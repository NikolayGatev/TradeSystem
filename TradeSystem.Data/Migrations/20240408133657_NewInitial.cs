using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class NewInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2300df3-59d6-4f4b-922a-19fb4941b6c5", "AQAAAAEAACcQAAAAEEnLxBSZMEwf0SyAhdKbrG+17o7QLk9/YJNlUpMx+9sxqjLeSqHoCqdAzSL1rLNo8g==", "068ac1ea-f912-4624-a400-65ac5516db2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee0c6d0b-3e8a-4189-a08d-37af637e124e", "AQAAAAEAACcQAAAAEJ+YCCkUh0oWhm+eCd5kGMHEv9VOHD71ZScdkhCu+IjKnRYc62CWe4kYTdXtSLr1Rg==", "fd4cc65f-4e9d-4b0b-8907-904d87a1b431" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 968, DateTimeKind.Utc).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 968, DateTimeKind.Utc).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 968, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 956, DateTimeKind.Utc).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 956, DateTimeKind.Utc).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 956, DateTimeKind.Utc).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 956, DateTimeKind.Utc).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 956, DateTimeKind.Utc).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 956, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 956, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 956, DateTimeKind.Utc).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 36, 56, 968, DateTimeKind.Utc).AddTicks(7139));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e977cc9b-1d55-4fb5-aaf1-6946dc064edf", "AQAAAAEAACcQAAAAELjltyG2UO85Z+4zb3NjPu5HvVZag1QO3c1qUgHNMKakIiaFYHDYft/W08VP/SnNwA==", "88c7ad56-9bf5-4035-b883-01b0e28e4985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ae48d0c-c7bb-43a8-8b88-6e2d22290c7a", "AQAAAAEAACcQAAAAELxamPZWCgMSQgij/nonS5GEL1zY7ZEfnFR0LULNv/wOvVrvK08gvLDS4GMithr0pg==", "f392e3e5-a39d-4585-a532-5241cc38c755" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 677, DateTimeKind.Utc).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 677, DateTimeKind.Utc).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 677, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 664, DateTimeKind.Utc).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 664, DateTimeKind.Utc).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 664, DateTimeKind.Utc).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 664, DateTimeKind.Utc).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 664, DateTimeKind.Utc).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 664, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 664, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 664, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 8, 13, 31, 0, 677, DateTimeKind.Utc).AddTicks(327));
        }
    }
}
