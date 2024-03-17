using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class AddedResultFromDataChecking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreatedAcount",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "IsCreatedAcount",
                table: "DataOfCorporateClients");

            migrationBuilder.AddColumn<int>(
                name: "DataChecking",
                table: "DataOfIndividualClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DataChecking",
                table: "DataOfCorporateClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "745ca12f-7156-4799-ba60-88a8b71698a0", "AQAAAAEAACcQAAAAEPZEz4916ZPzUUA4ZC06yRKyK0/ufnXpODvaK+82brKOdFuZWmatzHgvzUYeDiLH0g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "491d5585-980f-4997-ab71-f4c7150d99ce", "AQAAAAEAACcQAAAAEDz0mJQC9C1boqrAMwCWpmpoB/C24gkQ3d2vxVWaHSszanLJtav1z0tTwm/MgJcAuQ==" });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 14, 18, 34, 586, DateTimeKind.Local).AddTicks(9401));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataChecking",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "DataChecking",
                table: "DataOfCorporateClients");

            migrationBuilder.AddColumn<bool>(
                name: "IsCreatedAcount",
                table: "DataOfIndividualClients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCreatedAcount",
                table: "DataOfCorporateClients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3044958-247f-4316-b5c1-d63c31743728", "AQAAAAEAACcQAAAAEOh4bx+X+3lWaRXtEFNYKtKCCHz3u1Q+uBTAg4CZ3EXgUGkHQBlnju7fP7ughmMrNQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f855936c-6608-4d06-971b-520061576d86", "AQAAAAEAACcQAAAAEHHWLqBgUtX2QDjFHm6ep2AHJTEzu5Hjq6FFVo/e4yr1T5buNjJJ5wqKMNz3KCwqSQ==" });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 10, 9, 38, 45, 22, DateTimeKind.Local).AddTicks(2));
        }
    }
}
