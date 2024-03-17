using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class CorectReferenceDataOfClientAndAdminstrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DataOfCorporateClients_DataOfCorporateClientId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DataOfIndividualClients_DataOfIndividualClientId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ApplicationUserId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_DataOfCorporateClientId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_DataOfIndividualClientId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DataOfCorporateClientId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DataOfIndividualClientId",
                table: "Clients");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityDocumentId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthorisedOn",
                table: "DataOfIndividualClients",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityDocumentId",
                table: "DataOfCorporateClients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthorisedOn",
                table: "DataOfCorporateClients",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorId",
                table: "DataOfCorporateClients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "DataOfCorporateClients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "DataOfCorporateClients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Floor",
                table: "Addresses",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<byte>(
                name: "Flat",
                table: "Addresses",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), 0, "2196fbe2-986b-4e63-a5db-842336c90102", "client.com", false, false, null, "client.com", "client.com", "AQAAAAEAACcQAAAAEN0UcNvCORyqcUshjB45rmTqh5qQI++xru4rA9ry6rqrCskW62fh19D7uaQe9MNXoQ==", null, false, null, false, "client.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("dea12856-c198-4129-b3f3-b893d8395082"), 0, "5fe878b0-4e0e-4f3b-9761-fc9025a03311", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEOvTCjYwpbDlg3BiDVQTc9LQdJiZRmd0MWjg9cwq+L9LxavGGwA0xAWQDGkoWZM5cg==", null, false, null, false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Bulgaria" });

            migrationBuilder.InsertData(
                table: "Adminstrators",
                columns: new[] { "Id", "ApplicationUserId", "DivisionId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"), new Guid("dea12856-c198-4129-b3f3-b893d8395082"), 1, "Admin", "Compaince", "1234567890" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CountryId", "Flat", "Floor", "Number", "PostCode", "Street", "TownId", "district" },
                values: new object[] { new Guid("130a7006-f51d-4a2c-8796-92b0438a1293"), 1, null, null, "43", "5300", null, 1, null });

            migrationBuilder.InsertData(
                table: "DataOfIndividualClients",
                columns: new[] { "Id", "AddressId", "AdministratorId", "ApplicationUserId", "AuthorisedOn", "ClientId", "CreatedOn", "DateOfBirth", "FirstName", "IdentityDocumentId", "IsCreatedAcount", "NationalIdentityNumber", "NationalityId", "PhoneNumber", "SecondName", "Surname" },
                values: new object[] { new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"), new Guid("130a7006-f51d-4a2c-8796-92b0438a1293"), null, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), null, null, new DateTime(2024, 3, 8, 13, 46, 52, 386, DateTimeKind.Local).AddTicks(3207), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petko", null, false, "", 1, "1234456", null, "Client" });

            migrationBuilder.CreateIndex(
                name: "IX_DataOfIndividualClients_AdministratorId",
                table: "DataOfIndividualClients",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfIndividualClients_ApplicationUserId",
                table: "DataOfIndividualClients",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfIndividualClients_ClientId",
                table: "DataOfIndividualClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfCorporateClients_AdministratorId",
                table: "DataOfCorporateClients",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfCorporateClients_ApplicationUserId",
                table: "DataOfCorporateClients",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfCorporateClients_ClientId",
                table: "DataOfCorporateClients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_Adminstrators_AdministratorId",
                table: "DataOfCorporateClients",
                column: "AdministratorId",
                principalTable: "Adminstrators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_AspNetUsers_ApplicationUserId",
                table: "DataOfCorporateClients",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_Clients_ClientId",
                table: "DataOfCorporateClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfCorporateClients",
                column: "IdentityDocumentId",
                principalTable: "IdentityDocuments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_Adminstrators_AdministratorId",
                table: "DataOfIndividualClients",
                column: "AdministratorId",
                principalTable: "Adminstrators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_AspNetUsers_ApplicationUserId",
                table: "DataOfIndividualClients",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_Clients_ClientId",
                table: "DataOfIndividualClients",
                column: "ClientId",
                principalTable: "Clients",
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
                name: "FK_DataOfCorporateClients_Adminstrators_AdministratorId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_AspNetUsers_ApplicationUserId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_Clients_ClientId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_Adminstrators_AdministratorId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_AspNetUsers_ApplicationUserId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_Clients_ClientId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfIndividualClients_AdministratorId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfIndividualClients_ApplicationUserId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfIndividualClients_ClientId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfCorporateClients_AdministratorId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfCorporateClients_ApplicationUserId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfCorporateClients_ClientId",
                table: "DataOfCorporateClients");

            migrationBuilder.DeleteData(
                table: "Adminstrators",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"));

            migrationBuilder.DeleteData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("130a7006-f51d-4a2c-8796-92b0438a1293"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"));

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "DataOfCorporateClients");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityDocumentId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthorisedOn",
                table: "DataOfIndividualClients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthorisedOn",
                table: "DataOfCorporateClients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DataOfCorporateClientId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DataOfIndividualClientId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Floor",
                table: "Addresses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Flat",
                table: "Addresses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ApplicationUserId",
                table: "Clients",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DataOfCorporateClientId",
                table: "Clients",
                column: "DataOfCorporateClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DataOfIndividualClientId",
                table: "Clients",
                column: "DataOfIndividualClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId",
                table: "Clients",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_DataOfCorporateClients_DataOfCorporateClientId",
                table: "Clients",
                column: "DataOfCorporateClientId",
                principalTable: "DataOfCorporateClients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_DataOfIndividualClients_DataOfIndividualClientId",
                table: "Clients",
                column: "DataOfIndividualClientId",
                principalTable: "DataOfIndividualClients",
                principalColumn: "Id");

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
