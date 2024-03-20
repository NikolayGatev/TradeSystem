using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class DeletedEntityAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_Addresses_AddressId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_Addresses_AddressId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_DataOfIndividualClients_AddressId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfCorporateClients_AddressId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "DataOfCorporateClients");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DataOfIndividualClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "DataOfIndividualClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DataOfCorporateClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "DataOfCorporateClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2672379-827c-4ce7-8255-f3463a741376", "AQAAAAEAACcQAAAAEAQfQB9LNzOTd4SBX6I37vVdmJCvDmHjVa4nbMv2JMoEfYrjcy0TGr7SZ9SMslimKw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8bb02406-e1d6-4473-9c7f-9870d7e0fead", "AQAAAAEAACcQAAAAEGJyFP4tKgcdszfFj1Bhslmf9/+lQEbCeTI/tmCifpwwBxTAz9LqY0YAMqZO1A30SA==" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Italy" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Germany" }
                });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                columns: new[] { "Address", "CreatedOn", "TownId" },
                values: new object[] { "130a7006-f51d-4a2c-8796-92b0438a1293", new DateTime(2024, 3, 19, 21, 51, 32, 202, DateTimeKind.Local).AddTicks(7794), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DataOfIndividualClients_TownId",
                table: "DataOfIndividualClients",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfCorporateClients_TownId",
                table: "DataOfCorporateClients",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_Towns_TownId",
                table: "DataOfCorporateClients",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_Towns_TownId",
                table: "DataOfIndividualClients",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_Towns_TownId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_Towns_TownId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfIndividualClients_TownId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfCorporateClients_TownId",
                table: "DataOfCorporateClients");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DataOfCorporateClients");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "DataOfCorporateClients");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "DataOfCorporateClients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Flat = table.Column<byte>(type: "tinyint", nullable: true),
                    Floor = table.Column<byte>(type: "tinyint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "Flat", "Floor", "IsDeleted", "ModifiedOn", "Number", "PostCode", "Street", "TownId", "district" },
                values: new object[] { new Guid("130a7006-f51d-4a2c-8796-92b0438a1293"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, null, "43", "5300", null, 1, null });

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
                columns: new[] { "AddressId", "CreatedOn" },
                values: new object[] { new Guid("130a7006-f51d-4a2c-8796-92b0438a1293"), new DateTime(2024, 3, 17, 14, 18, 34, 586, DateTimeKind.Local).AddTicks(9401) });

            migrationBuilder.CreateIndex(
                name: "IX_DataOfIndividualClients_AddressId",
                table: "DataOfIndividualClients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfCorporateClients_AddressId",
                table: "DataOfCorporateClients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TownId",
                table: "Addresses",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_Addresses_AddressId",
                table: "DataOfCorporateClients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_Addresses_AddressId",
                table: "DataOfIndividualClients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
