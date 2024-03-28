using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class ChangeSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfIndividualClients");

            migrationBuilder.DeleteData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"));

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "9c5f934f-ed28-49b4-87e0-c3d851756202", "client@gmail.com", "client@gmail.com", "client@gmail.com", "AQAAAAEAACcQAAAAEPTn1Twy6LDHAozWzTrBlTejosYsYvyVlRTVwgJuOrBDEtSWnc3q8vYiaCrPRY9mRw==", "client@gmail.com" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfCorporateClients",
                column: "IdentityDocumentId",
                principalTable: "IdentityDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfIndividualClients",
                column: "IdentityDocumentId",
                principalTable: "IdentityDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "6e64ecfe-70e1-41c9-a450-243e22479067", "client.com", "client.com", "client.com", "AQAAAAEAACcQAAAAEO93uozI+NnpLcTLAYikt19G/KOojRLEocg2inMA9VJMbR0beitsC/9E+Wg+N/Veiw==", "client.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6fb619f9-ac0c-4055-a53a-14ad6edb0c82", "AQAAAAEAACcQAAAAEC4RmzKRY3MIo+R+XT72EJ5lwl5tm7zkLCzm7imUJAQ68lmBxRpvzG4s1BSNT/fm3w==" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DataOfIndividualClients",
                columns: new[] { "Id", "Address", "ApplicationUserId", "AuthorisedOn", "ClientId", "CreatedOn", "DataChecking", "DateOfBirth", "EmployeeId", "FirstName", "IdentityDocumentId", "ModifiedOn", "NationalIdentityNumber", "NationalityId", "PhoneNumber", "SecondName", "Surname", "TownId" },
                values: new object[] { new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"), "130a7006-f51d-4a2c-8796-92b0438a1293", new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), null, null, new DateTime(2024, 3, 20, 17, 50, 30, 290, DateTimeKind.Local).AddTicks(2927), 0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Petko", null, null, "", 1, "1234456", null, "Client", 1 });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
