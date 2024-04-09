using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class RemoveAdministratorAndDepoxitManeyModelsAndAddedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "bb91ad5e-e879-4447-89ae-57f7eaed8b21", "individual@gmail.com", "individual@gmail.com", "individual@gmail.com", "AQAAAAEAACcQAAAAEN1eE/qyKXBtgpJZiRqNCLs7NFehj8Sj8kdI+LDL+84JGoYW6iyyQqpqrDwWQSGYFQ==", "477bbedc-f60e-4129-aaae-32bd6586e840", "individual@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5f1af77d-322b-48aa-badc-eaf933166f68", "admin@gmail.com", "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEJ1wCVirFQKUG9zSNl/0XKboXOqdh3KSowCPGU7p0oHD0okkKVkMVNF2cQiJZoUFUA==", "58e2a918-9e48-48c3-8920-58e8f99d306f", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb", 0, "29a0a44d-3d9b-4893-8254-f5ab434a4b70", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "employee@gmail.com", false, false, false, null, null, "employee@gmail.com", "employee@gmail.com", "AQAAAAEAACcQAAAAEBnC1TAXJOo0cuhSoAUA+Qwl/f3ZMzCSNJjNrS10vJ58tPZNwUhBk8N40etevjii0A==", null, false, "e543baf4-b519-4d7b-9957-cedee0b37da5", false, "employee@gmail.com" },
                    { "7586d7f6-e626-4e06-999e-7c977382c6de", 0, "86d134b4-41e0-4db9-b684-ecdfac1d968a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "corporative@gmail.com", false, false, false, null, null, "corporative@gmail.com", "corporative@gmail.com", "AQAAAAEAACcQAAAAEHEtb1easK55OgoZrroTDjxWqh1K0ChW3e99C4AVZrZUsXK++lfAH1RmjTyXuQrnHA==", null, false, "d6a41022-68ed-4d47-a6b5-13320e8099d1", false, "corporative@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Balance", "BlockedSum", "CreatedOn", "DeletedOn", "IsDeleted", "IsIndividual", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 50000m, 0m, new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(540), null, false, true, null },
                    { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 70000m, 0m, new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(564), null, false, false, null }
                });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                columns: new[] { "CreatedOn", "IsApproved", "LastName" },
                values: new object[] { new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(9275), true, "Administrator" });

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ClientId", "CreatedOn", "DeletedOn", "FinancialInstrumentId", "IsDeleted", "ModifiedOn", "Price", "Volume" },
                values: new object[,]
                {
                    { new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"), null, new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1167), null, 2, false, null, 10m, 200L },
                    { new Guid("c4824a81-6996-41a6-bf31-95dc69266175"), null, new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1156), null, 1, false, null, 10m, 100L }
                });

            migrationBuilder.InsertData(
                table: "ClientFinancialInstruments",
                columns: new[] { "ClientId", "FinancialInstrumentId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Volume" },
                values: new object[,]
                {
                    { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 1, new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(639), null, false, null, 5000L },
                    { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 2, new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(646), null, false, null, 6000L },
                    { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 3, new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(648), null, false, null, 3000L },
                    { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 4, new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(649), null, false, null, 7000L }
                });

            migrationBuilder.InsertData(
                table: "DataOfIndividualClients",
                columns: new[] { "Id", "Address", "ApplicationUserId", "AuthorisedOn", "ClientId", "CreatedOn", "DataChecking", "DateOfBirth", "EmployeeId", "FirstName", "IdentityDocumentId", "ModifiedOn", "NationalIdentityNumber", "NationalityId", "PhoneNumber", "SecondName", "Surname", "TownId" },
                values: new object[] { new Guid("f316a20f-0bfa-4412-81a1-50bcb6562bc0"), "Ovcha Kupel 58", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", new DateTime(2024, 4, 9, 10, 0, 20, 13, DateTimeKind.Local).AddTicks(868), new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), new DateTime(2024, 4, 9, 10, 0, 20, 13, DateTimeKind.Local).AddTicks(865), 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"), "Individual", null, null, "BC1245643566", 1, "1234456", null, "Invidualov", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ApplicationUserId", "CreatedOn", "DeletedOn", "DivisionId", "FirstName", "IsApproved", "IsDeleted", "LastName", "ModifiedOn", "PhoneNumber" },
                values: new object[] { new Guid("4bcfd374-c252-4193-8bfe-5e84379984cf"), "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb", new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(9299), null, 1, "Employee", true, false, "Employeev", null, "2234567890" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ActiveVolume", "ClientId", "CreatedOn", "DeletedOn", "FinancialInstrumentId", "InitialVolume", "IsBid", "IsDeleted", "ModifiedOn", "Price" },
                values: new object[,]
                {
                    { new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"), 0L, new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1053), null, 2, 200L, true, true, null, 10m },
                    { new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"), 0L, new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(989), null, 2, 200L, true, true, null, 10m },
                    { new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"), 0L, new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1050), null, 1, 100L, false, true, null, 10m },
                    { new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"), 0L, new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(977), null, 1, 100L, true, true, null, 10m },
                    { new Guid("9edba98d-8ee3-4e2e-8c38-dd18477f5a81"), 100L, new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1042), null, 1, 100L, false, false, null, 10m },
                    { new Guid("b5cf01f7-2fae-402e-b8f5-20b0ffcf4fac"), 200L, new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1058), null, 4, 200L, false, false, null, 5m },
                    { new Guid("c0cfddfe-946d-40b5-9911-e87f4c3598be"), 100L, new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1056), null, 3, 100L, false, false, null, 10m },
                    { new Guid("f74db81b-3dc9-4841-8bd0-6029600200aa"), 200L, new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1046), null, 2, 200L, false, false, null, 5m }
                });

            migrationBuilder.InsertData(
                table: "DataOfCorporateClients",
                columns: new[] { "Id", "Address", "ApplicationUserId", "AuthorisedOn", "ClientId", "CreatedOn", "DataChecking", "EmployeeId", "IdentityDocumentId", "LegalForm", "ModifiedOn", "Name", "NameOfRepresentative", "NationalIdentityNumber", "NationalityId", "PhoneNumber", "TownId" },
                values: new object[] { new Guid("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"), "Krasna Polqna 58", "7586d7f6-e626-4e06-999e-7c977382c6de", new DateTime(2024, 4, 9, 10, 0, 20, 13, DateTimeKind.Local).AddTicks(772), new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), new DateTime(2024, 4, 9, 10, 0, 20, 13, DateTimeKind.Local).AddTicks(741), 1, new Guid("4bcfd374-c252-4193-8bfe-5e84379984cf"), null, "EOOD", null, "Corporation", "Petar petrov", "6789945435677", 1, "3234456", 1 });

            migrationBuilder.InsertData(
                table: "TradeOrders",
                columns: new[] { "OrderId", "TradeId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Volume" },
                values: new object[,]
                {
                    { new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1256), null, false, null, 100L },
                    { new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1254), null, false, null, 100L },
                    { new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1244), null, false, null, 100L },
                    { new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175"), new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1252), null, false, null, 100L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 1 });

            migrationBuilder.DeleteData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 2 });

            migrationBuilder.DeleteData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 3 });

            migrationBuilder.DeleteData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 4 });

            migrationBuilder.DeleteData(
                table: "DataOfCorporateClients",
                keyColumn: "Id",
                keyValue: new Guid("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"));

            migrationBuilder.DeleteData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("f316a20f-0bfa-4412-81a1-50bcb6562bc0"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("9edba98d-8ee3-4e2e-8c38-dd18477f5a81"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b5cf01f7-2fae-402e-b8f5-20b0ffcf4fac"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("c0cfddfe-946d-40b5-9911-e87f4c3598be"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f74db81b-3dc9-4841-8bd0-6029600200aa"));

            migrationBuilder.DeleteData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") });

            migrationBuilder.DeleteData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") });

            migrationBuilder.DeleteData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") });

            migrationBuilder.DeleteData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7586d7f6-e626-4e06-999e-7c977382c6de");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4bcfd374-c252-4193-8bfe-5e84379984cf"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"));

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"));

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("c4824a81-6996-41a6-bf31-95dc69266175"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"));

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a2300df3-59d6-4f4b-922a-19fb4941b6c5", "client@gmail.com", "client@gmail.com", "client@gmail.com", "AQAAAAEAACcQAAAAEEnLxBSZMEwf0SyAhdKbrG+17o7QLk9/YJNlUpMx+9sxqjLeSqHoCqdAzSL1rLNo8g==", "068ac1ea-f912-4624-a400-65ac5516db2f", "client@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ee0c6d0b-3e8a-4189-a08d-37af637e124e", "admin@mail.com", "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEJ+YCCkUh0oWhm+eCd5kGMHEv9VOHD71ZScdkhCu+IjKnRYc62CWe4kYTdXtSLr1Rg==", "fd4cc65f-4e9d-4b0b-8907-904d87a1b431", "admin@mail.com" });

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
                columns: new[] { "CreatedOn", "LastName" },
                values: new object[] { new DateTime(2024, 4, 8, 13, 36, 56, 956, DateTimeKind.Utc).AddTicks(2765), "Compaince" });

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
    }
}
