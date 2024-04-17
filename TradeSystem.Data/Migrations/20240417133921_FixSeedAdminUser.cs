using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class FixSeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3e40467-62ec-4b03-905b-ac0d4dcf88ba", "AQAAAAEAACcQAAAAEPvdMwGo80wKfVn8QerWvzIVj4VJTiIpiF2yLazt3VbgAonJz7GBK31R2U6L5GE+ng==", "4da2ba68-bd61-4383-8bf7-0bf85b1cbbd0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5789eeae-f874-47d0-9ef8-30c6a35e5af3", "AQAAAAEAACcQAAAAELiS/Out2ji2OCnZlHosdRq+HiUbLDztbACOHkcu4ZwiUIvrjpEhVYmWW7FIvGuwlg==", "5c63d806-03f5-46df-a187-2b4713e00dc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7586d7f6-e626-4e06-999e-7c977382c6de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a770d551-fa10-4559-b587-ef0cf50f0f20", "AQAAAAEAACcQAAAAEDX8guGDJz4zO5V3a1c9L4vZvePeBLNF/fCejbrnGRvO0u77PNg5MWtk/uMAOu64Qw==", "0972135c-c83f-4fff-946a-0a71402cbfc5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65946c99-d6bf-4703-94f4-1b3a62c91116", "admin@gmail.com", "AQAAAAEAACcQAAAAEFbKcdccy8dIGQNLJHVLbC143WL5e7Qeu3CYIg4azFf+YKkJZ+7WgkIAvhxMguYSXQ==", "916f20da-5b5e-4b90-8927-ac833de1e41a" });

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 1 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(1573));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "DataOfCorporateClients",
                keyColumn: "Id",
                keyValue: new Guid("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"),
                columns: new[] { "AuthorisedOn", "CreatedOn" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 39, 18, 836, DateTimeKind.Local).AddTicks(2757), new DateTime(2024, 4, 17, 16, 39, 18, 836, DateTimeKind.Local).AddTicks(2705) });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("f316a20f-0bfa-4412-81a1-50bcb6562bc0"),
                columns: new[] { "AuthorisedOn", "CreatedOn" },
                values: new object[] { new DateTime(2024, 4, 17, 16, 39, 18, 836, DateTimeKind.Local).AddTicks(2994), new DateTime(2024, 4, 17, 16, 39, 18, 836, DateTimeKind.Local).AddTicks(2985) });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 789, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 789, DateTimeKind.Utc).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 789, DateTimeKind.Utc).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4bcfd374-c252-4193-8bfe-5e84379984cf"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 790, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 790, DateTimeKind.Utc).AddTicks(718));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 789, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 789, DateTimeKind.Utc).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 789, DateTimeKind.Utc).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 789, DateTimeKind.Utc).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("9edba98d-8ee3-4e2e-8c38-dd18477f5a81"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3164));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b5cf01f7-2fae-402e-b8f5-20b0ffcf4fac"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3201));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("c0cfddfe-946d-40b5-9911-e87f4c3598be"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3196));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f74db81b-3dc9-4841-8bd0-6029600200aa"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("c4824a81-6996-41a6-bf31-95dc69266175"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 17, 13, 39, 18, 836, DateTimeKind.Utc).AddTicks(3362));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42e9b49d-57be-43eb-ba65-41c9d92425ae", "AQAAAAEAACcQAAAAEBKlcK8OCDU776t/GgBLD5vvwomh40nqGXbh6MD3XWMJQ2YQ6rVqhi+PElzzAEK2AQ==", "865c5e67-2a3c-47f5-8b7c-0020706f9f3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d568a4b9-1e86-4055-b358-aac17c063419", "AQAAAAEAACcQAAAAEJU3qetB9luKwT+BsV5mIVOF9Kl4X5hbP1PzZjoJYf4hqb3mxk2llXg1DViAwpB8Aw==", "896bc5a0-9ba5-4d63-aaa0-e42ae46af489" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7586d7f6-e626-4e06-999e-7c977382c6de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b7dd7a4-5a5b-4058-abed-846c23c0726e", "AQAAAAEAACcQAAAAEJUvKNlE0OMCdWYc2BcUMyzaoLZGpRiVET1BiEN0pXRFx4NHgQFLcaNJYA77Ow8GRQ==", "bd5b44a8-eef7-4072-8236-5ce5cd2cd004" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e392ce5-8c3a-40bc-9c08-bb96111d51fb", "admin@gmail.comm", "AQAAAAEAACcQAAAAEJ6CuJE6Zr7K7U91/EGfzF4HkBP9YSOAnyFw6KAej7/h5S4UVcqZqgoUL0ydNo5h2w==", "59f3fc5e-95cb-4b96-a1c3-787158170deb" });

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 1 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "DataOfCorporateClients",
                keyColumn: "Id",
                keyValue: new Guid("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"),
                columns: new[] { "AuthorisedOn", "CreatedOn" },
                values: new object[] { new DateTime(2024, 4, 11, 21, 29, 5, 838, DateTimeKind.Local).AddTicks(9255), new DateTime(2024, 4, 11, 21, 29, 5, 838, DateTimeKind.Local).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("f316a20f-0bfa-4412-81a1-50bcb6562bc0"),
                columns: new[] { "AuthorisedOn", "CreatedOn" },
                values: new object[] { new DateTime(2024, 4, 11, 21, 29, 5, 838, DateTimeKind.Local).AddTicks(9339), new DateTime(2024, 4, 11, 21, 29, 5, 838, DateTimeKind.Local).AddTicks(9336) });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 814, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 814, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 814, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4bcfd374-c252-4193-8bfe-5e84379984cf"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 814, DateTimeKind.Utc).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 814, DateTimeKind.Utc).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 814, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 814, DateTimeKind.Utc).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 814, DateTimeKind.Utc).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 814, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("9edba98d-8ee3-4e2e-8c38-dd18477f5a81"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b5cf01f7-2fae-402e-b8f5-20b0ffcf4fac"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("c0cfddfe-946d-40b5-9911-e87f4c3598be"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f74db81b-3dc9-4841-8bd0-6029600200aa"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("c4824a81-6996-41a6-bf31-95dc69266175"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 18, 29, 5, 838, DateTimeKind.Utc).AddTicks(9549));
        }
    }
}
