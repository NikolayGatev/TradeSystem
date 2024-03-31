using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class FixIdentityDocumentIdInDataOfClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfIndividualClients");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityDocumentId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityDocumentId",
                table: "DataOfCorporateClients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfCorporateClients",
                column: "IdentityDocumentId",
                principalTable: "IdentityDocuments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfIndividualClients",
                column: "IdentityDocumentId",
                principalTable: "IdentityDocuments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfIndividualClients");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityDocumentId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityDocumentId",
                table: "DataOfCorporateClients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfCorporateClients",
                column: "IdentityDocumentId",
                principalTable: "IdentityDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfIndividualClients",
                column: "IdentityDocumentId",
                principalTable: "IdentityDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
