using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class AddedSeedInData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DataOfCorporateClients_DataOfCorporateClientId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DataOfIndividualClients_DataOfIndividualClientId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_Addresses_AddressId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_Countries_NationalityId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_IdentityDocuments_IdentityDocumentId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropTable(
                name: "DataOfCorporateClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataOfIndividualClients",
                table: "DataOfIndividualClients");

            migrationBuilder.RenameTable(
                name: "DataOfIndividualClients",
                newName: "DataOfClient");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfIndividualClients_NationalityId",
                table: "DataOfClient",
                newName: "IX_DataOfClient_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfIndividualClients_IdentityDocumentId",
                table: "DataOfClient",
                newName: "IX_DataOfClient_IdentityDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfIndividualClients_AddressId",
                table: "DataOfClient",
                newName: "IX_DataOfClient_AddressId");

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

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "DataOfClient",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "NationalIdentityNumber",
                table: "DataOfClient",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityDocumentId",
                table: "DataOfClient",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "DataOfClient",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "DataOfClient",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthorisedOn",
                table: "DataOfClient",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorId",
                table: "DataOfClient",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataOfIndividualClient_NationalIdentityNumber",
                table: "DataOfClient",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "DataOfClient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LegalForm",
                table: "DataOfClient",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DataOfClient",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfRepresentative",
                table: "DataOfClient",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataOfClient",
                table: "DataOfClient",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), 0, "836e252c-c90e-46fe-a32b-a1ff07b13c25", "client.com", false, false, null, "client.com", "client.com", "AQAAAAEAACcQAAAAEF/qe7aJuR50wOzVMR3BfZX1sUNLyG6rpqWBGdYRUX+bafHfQQJH5ISKx9W8Oadhbw==", null, false, null, false, "client.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("dea12856-c198-4129-b3f3-b893d8395082"), 0, "58cdbcfc-9fdb-4946-91a6-160b1cdc9925", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEKdQ+vcxDQ+F3Nd5iRkknkBW23V4+SVyN+UupQefg67Fb/Tpw3tlxZAbAkPYRQ3boQ==", null, false, null, false, "admin@mail.com" });

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
                table: "DataOfClient",
                columns: new[] { "Id", "AddressId", "AdministratorId", "AuthorisedOn", "CreatedOn", "DateOfBirth", "Discriminator", "FirstName", "IdentityDocumentId", "IsCreatedAcount", "DataOfIndividualClient_NationalIdentityNumber", "NationalityId", "PhoneNumber", "SecondName", "Surname" },
                values: new object[] { new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"), new Guid("130a7006-f51d-4a2c-8796-92b0438a1293"), null, null, new DateTime(2024, 3, 8, 12, 16, 50, 658, DateTimeKind.Local).AddTicks(539), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DataOfIndividualClient", "Petko", null, false, "", 1, "1234456", null, "Client" });

            migrationBuilder.CreateIndex(
                name: "IX_DataOfClient_AdministratorId",
                table: "DataOfClient",
                column: "AdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_DataOfClient_DataOfCorporateClientId",
                table: "Clients",
                column: "DataOfCorporateClientId",
                principalTable: "DataOfClient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_DataOfClient_DataOfIndividualClientId",
                table: "Clients",
                column: "DataOfIndividualClientId",
                principalTable: "DataOfClient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfClient_Addresses_AddressId",
                table: "DataOfClient",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfClient_Adminstrators_AdministratorId",
                table: "DataOfClient",
                column: "AdministratorId",
                principalTable: "Adminstrators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfClient_Countries_NationalityId",
                table: "DataOfClient",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfClient_IdentityDocuments_IdentityDocumentId",
                table: "DataOfClient",
                column: "IdentityDocumentId",
                principalTable: "IdentityDocuments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DataOfClient_DataOfCorporateClientId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DataOfClient_DataOfIndividualClientId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfClient_Addresses_AddressId",
                table: "DataOfClient");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfClient_Adminstrators_AdministratorId",
                table: "DataOfClient");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfClient_Countries_NationalityId",
                table: "DataOfClient");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfClient_IdentityDocuments_IdentityDocumentId",
                table: "DataOfClient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataOfClient",
                table: "DataOfClient");

            migrationBuilder.DropIndex(
                name: "IX_DataOfClient_AdministratorId",
                table: "DataOfClient");

            migrationBuilder.DeleteData(
                table: "Adminstrators",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"));

            migrationBuilder.DeleteData(
                table: "DataOfClient",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("130a7006-f51d-4a2c-8796-92b0438a1293"));

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
                table: "DataOfClient");

            migrationBuilder.DropColumn(
                name: "DataOfIndividualClient_NationalIdentityNumber",
                table: "DataOfClient");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "DataOfClient");

            migrationBuilder.DropColumn(
                name: "LegalForm",
                table: "DataOfClient");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DataOfClient");

            migrationBuilder.DropColumn(
                name: "NameOfRepresentative",
                table: "DataOfClient");

            migrationBuilder.RenameTable(
                name: "DataOfClient",
                newName: "DataOfIndividualClients");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfClient_NationalityId",
                table: "DataOfIndividualClients",
                newName: "IX_DataOfIndividualClients_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfClient_IdentityDocumentId",
                table: "DataOfIndividualClients",
                newName: "IX_DataOfIndividualClients_IdentityDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfClient_AddressId",
                table: "DataOfIndividualClients",
                newName: "IX_DataOfIndividualClients_AddressId");

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

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "DataOfIndividualClients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalIdentityNumber",
                table: "DataOfIndividualClients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityDocumentId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "DataOfIndividualClients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "DataOfIndividualClients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataOfIndividualClients",
                table: "DataOfIndividualClients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DataOfCorporateClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    AuthorisedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsCreatedAcount = table.Column<bool>(type: "bit", nullable: false),
                    LegalForm = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NameOfRepresentative = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NationalIdentityNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataOfCorporateClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataOfCorporateClients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataOfCorporateClients_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataOfCorporateClients_IdentityDocuments_IdentityDocumentId",
                        column: x => x.IdentityDocumentId,
                        principalTable: "IdentityDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataOfCorporateClients_AddressId",
                table: "DataOfCorporateClients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfCorporateClients_IdentityDocumentId",
                table: "DataOfCorporateClients",
                column: "IdentityDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfCorporateClients_NationalityId",
                table: "DataOfCorporateClients",
                column: "NationalityId");

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
                name: "FK_DataOfIndividualClients_Addresses_AddressId",
                table: "DataOfIndividualClients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_Countries_NationalityId",
                table: "DataOfIndividualClients",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
