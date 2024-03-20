using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class ChanchAdministratorEntityWithEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_Adminstrators_AdministratorId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_Adminstrators_AdministratorId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropTable(
                name: "Adminstrators");

            migrationBuilder.RenameColumn(
                name: "AdministratorId",
                table: "DataOfIndividualClients",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfIndividualClients_AdministratorId",
                table: "DataOfIndividualClients",
                newName: "IX_DataOfIndividualClients_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "AdministratorId",
                table: "DataOfCorporateClients",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfCorporateClients_AdministratorId",
                table: "DataOfCorporateClients",
                newName: "IX_DataOfCorporateClients_EmployeeId");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e64ecfe-70e1-41c9-a450-243e22479067", "AQAAAAEAACcQAAAAEO93uozI+NnpLcTLAYikt19G/KOojRLEocg2inMA9VJMbR0beitsC/9E+Wg+N/Veiw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6fb619f9-ac0c-4055-a53a-14ad6edb0c82", "AQAAAAEAACcQAAAAEC4RmzKRY3MIo+R+XT72EJ5lwl5tm7zkLCzm7imUJAQ68lmBxRpvzG4s1BSNT/fm3w==" });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 20, 17, 50, 30, 290, DateTimeKind.Local).AddTicks(2927));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ApplicationUserId", "CreatedOn", "DeletedOn", "DivisionId", "FirstName", "IsDeleted", "LastName", "ModifiedOn", "PhoneNumber" },
                values: new object[] { new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"), new Guid("dea12856-c198-4129-b3f3-b893d8395082"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Admin", false, "Compaince", null, "1234567890" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ApplicationUserId",
                table: "Employees",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DivisionId",
                table: "Employees",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_Employees_EmployeeId",
                table: "DataOfCorporateClients",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_Employees_EmployeeId",
                table: "DataOfIndividualClients",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_Employees_EmployeeId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_Employees_EmployeeId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "DataOfIndividualClients",
                newName: "AdministratorId");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfIndividualClients_EmployeeId",
                table: "DataOfIndividualClients",
                newName: "IX_DataOfIndividualClients_AdministratorId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "DataOfCorporateClients",
                newName: "AdministratorId");

            migrationBuilder.RenameIndex(
                name: "IX_DataOfCorporateClients_EmployeeId",
                table: "DataOfCorporateClients",
                newName: "IX_DataOfCorporateClients_AdministratorId");

            migrationBuilder.CreateTable(
                name: "Adminstrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminstrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adminstrators_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adminstrators_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adminstrators",
                columns: new[] { "Id", "ApplicationUserId", "CreatedOn", "DeletedOn", "DivisionId", "FirstName", "IsDeleted", "LastName", "ModifiedOn", "PhoneNumber" },
                values: new object[] { new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"), new Guid("dea12856-c198-4129-b3f3-b893d8395082"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Admin", false, "Compaince", null, "1234567890" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6d161f4-1266-4027-a58a-f95874b21228", "AQAAAAEAACcQAAAAEOIFsczDYgQi5mlkVybjMt124Lv4vdUf1WODEBjvtuzwW0Yt4hWdVB7k4EGBXUbBiw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1c876ac-906c-48d7-afde-f9ffd8303a22", "AQAAAAEAACcQAAAAEMjWonhIjTEKbLWxUrkx+XRNblh4Z1cyxEDW5Ycos8K17EH6+QQzBzTMXCpc2ukgAg==" });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 20, 11, 15, 25, 393, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.CreateIndex(
                name: "IX_Adminstrators_ApplicationUserId",
                table: "Adminstrators",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Adminstrators_DivisionId",
                table: "Adminstrators",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_Adminstrators_AdministratorId",
                table: "DataOfCorporateClients",
                column: "AdministratorId",
                principalTable: "Adminstrators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_Adminstrators_AdministratorId",
                table: "DataOfIndividualClients",
                column: "AdministratorId",
                principalTable: "Adminstrators",
                principalColumn: "Id");
        }
    }
}
