using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class CreateBlockedSumInClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BlockedSum",
                table: "Clients",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f89dd540-74ca-4661-a335-381554df1466", "AQAAAAEAACcQAAAAEPW5uc43aIDFIOxD1jn9eEEE/KE9OPJag5GA/d+TE0N8KDYmSt8USIlGg+mBGXaMrw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "527950b3-69d8-49d9-8dd1-ae8cde3ad02e", "AQAAAAEAACcQAAAAEKUyB6dHwomTsEKBALK6JtFh/Na2y3R/L6jykaKqQOXCMLYgmlXAMz4dFL28TfKPtw==" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 136, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 136, DateTimeKind.Utc).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 136, DateTimeKind.Utc).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 124, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 124, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 124, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 124, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 124, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 124, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 124, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 124, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 30, 18, 7, 57, 136, DateTimeKind.Utc).AddTicks(5736));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockedSum",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c5f934f-ed28-49b4-87e0-c3d851756202", "AQAAAAEAACcQAAAAEPTn1Twy6LDHAozWzTrBlTejosYsYvyVlRTVwgJuOrBDEtSWnc3q8vYiaCrPRY9mRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e05148c-41dc-4785-bf3f-321a20a5b2cf", "AQAAAAEAACcQAAAAEMCp3B4pZ5ns4QNqj6xqN0OGFibaTfDR6/d80E0pdkrjmZnDVelwxY0M81myDsPCHw==" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 896, DateTimeKind.Utc).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 896, DateTimeKind.Utc).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 896, DateTimeKind.Utc).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 884, DateTimeKind.Utc).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 884, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 884, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 884, DateTimeKind.Utc).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 884, DateTimeKind.Utc).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 884, DateTimeKind.Utc).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 884, DateTimeKind.Utc).AddTicks(3892));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 884, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 28, 13, 4, 21, 896, DateTimeKind.Utc).AddTicks(8044));
        }
    }
}
