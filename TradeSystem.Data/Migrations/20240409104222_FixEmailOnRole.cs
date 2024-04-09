using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class FixEmailOnRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24633193-77ab-430c-bc70-da43842e81dc", "AQAAAAEAACcQAAAAEBU90nA8egtkRVX2Bk4YJbAkoUuEKzEc9O1ZLvhkV8TgZWXWWqNGmPaf1a5uMvlk7A==", "2dc0ef15-25e3-4c2f-9fb7-3e1fed35e66a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "858a2083-fbc5-4c0a-958b-d0d61a35fc40", "AQAAAAEAACcQAAAAEBNf5dOuEl7UkUGetFm3wmqo+Q82geaTEseZtnxUnPiMs//3+0jGoTfNtImvW8CGvg==", "6ebcd868-1a1c-476f-aee4-bad83b053ae1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7586d7f6-e626-4e06-999e-7c977382c6de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "109a8c46-d0a2-4d49-98d9-a80b6b9a851b", "AQAAAAEAACcQAAAAEFxTZ2Q6qr2sK7Zm27jFUyFbz3nv+vSLNYEKf8tAvgK2WBeDJsDZC6nUCV3+X6NWHQ==", "409a1b0f-6514-4938-a29a-8bbd99236b7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c4e9759-a9e2-4979-9b6e-a10b34071564", "admin@gmail.comm", "AQAAAAEAACcQAAAAELPL6EbhYHfdmlEObfbzernjM5xi30yP1KWeaSMesWDzO332WjJl2ZWIbcpT9FXO0A==", "7df932f8-4167-46e6-ba6a-ce618a7deebb" });

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 1 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "DataOfCorporateClients",
                keyColumn: "Id",
                keyValue: new Guid("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"),
                columns: new[] { "AuthorisedOn", "CreatedOn" },
                values: new object[] { new DateTime(2024, 4, 9, 13, 42, 21, 645, DateTimeKind.Local).AddTicks(1678), new DateTime(2024, 4, 9, 13, 42, 21, 645, DateTimeKind.Local).AddTicks(1642) });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("f316a20f-0bfa-4412-81a1-50bcb6562bc0"),
                columns: new[] { "AuthorisedOn", "CreatedOn" },
                values: new object[] { new DateTime(2024, 4, 9, 13, 42, 21, 645, DateTimeKind.Local).AddTicks(1769), new DateTime(2024, 4, 9, 13, 42, 21, 645, DateTimeKind.Local).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 620, DateTimeKind.Utc).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 620, DateTimeKind.Utc).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 620, DateTimeKind.Utc).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4bcfd374-c252-4193-8bfe-5e84379984cf"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 620, DateTimeKind.Utc).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 620, DateTimeKind.Utc).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 620, DateTimeKind.Utc).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 620, DateTimeKind.Utc).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 620, DateTimeKind.Utc).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "FinancialInstruments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 620, DateTimeKind.Utc).AddTicks(1041));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("9edba98d-8ee3-4e2e-8c38-dd18477f5a81"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b5cf01f7-2fae-402e-b8f5-20b0ffcf4fac"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("c0cfddfe-946d-40b5-9911-e87f4c3598be"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f74db81b-3dc9-4841-8bd0-6029600200aa"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("c4824a81-6996-41a6-bf31-95dc69266175"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 10, 42, 21, 645, DateTimeKind.Utc).AddTicks(1975));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29a0a44d-3d9b-4893-8254-f5ab434a4b70", "AQAAAAEAACcQAAAAEBnC1TAXJOo0cuhSoAUA+Qwl/f3ZMzCSNJjNrS10vJ58tPZNwUhBk8N40etevjii0A==", "e543baf4-b519-4d7b-9957-cedee0b37da5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb91ad5e-e879-4447-89ae-57f7eaed8b21", "AQAAAAEAACcQAAAAEN1eE/qyKXBtgpJZiRqNCLs7NFehj8Sj8kdI+LDL+84JGoYW6iyyQqpqrDwWQSGYFQ==", "477bbedc-f60e-4129-aaae-32bd6586e840" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7586d7f6-e626-4e06-999e-7c977382c6de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86d134b4-41e0-4db9-b684-ecdfac1d968a", "AQAAAAEAACcQAAAAEHEtb1easK55OgoZrroTDjxWqh1K0ChW3e99C4AVZrZUsXK++lfAH1RmjTyXuQrnHA==", "d6a41022-68ed-4d47-a6b5-13320e8099d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f1af77d-322b-48aa-badc-eaf933166f68", "admin@gmail.com", "AQAAAAEAACcQAAAAEJ1wCVirFQKUG9zSNl/0XKboXOqdh3KSowCPGU7p0oHD0okkKVkMVNF2cQiJZoUFUA==", "58e2a918-9e48-48c3-8920-58e8f99d306f" });

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 1 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(639));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "ClientFinancialInstruments",
                keyColumns: new[] { "ClientId", "FinancialInstrumentId" },
                keyValues: new object[] { new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"), 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(564));

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
                table: "DataOfCorporateClients",
                keyColumn: "Id",
                keyValue: new Guid("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"),
                columns: new[] { "AuthorisedOn", "CreatedOn" },
                values: new object[] { new DateTime(2024, 4, 9, 10, 0, 20, 13, DateTimeKind.Local).AddTicks(772), new DateTime(2024, 4, 9, 10, 0, 20, 13, DateTimeKind.Local).AddTicks(741) });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("f316a20f-0bfa-4412-81a1-50bcb6562bc0"),
                columns: new[] { "AuthorisedOn", "CreatedOn" },
                values: new object[] { new DateTime(2024, 4, 9, 10, 0, 20, 13, DateTimeKind.Local).AddTicks(868), new DateTime(2024, 4, 9, 10, 0, 20, 13, DateTimeKind.Local).AddTicks(865) });

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
                keyValue: new Guid("4bcfd374-c252-4193-8bfe-5e84379984cf"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("67524a1e-2595-440e-a6d2-103aaf179a08"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 19, 987, DateTimeKind.Utc).AddTicks(9275));

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
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1050));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("9edba98d-8ee3-4e2e-8c38-dd18477f5a81"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b5cf01f7-2fae-402e-b8f5-20b0ffcf4fac"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("c0cfddfe-946d-40b5-9911-e87f4c3598be"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f74db81b-3dc9-4841-8bd0-6029600200aa"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1046));

            migrationBuilder.UpdateData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("417d6699-1b1d-45c9-9ebb-27fbef1dae84"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"), new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("55a73acc-6a01-43bc-b8d1-f81cd707f335"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "TradeOrders",
                keyColumns: new[] { "OrderId", "TradeId" },
                keyValues: new object[] { new Guid("98807339-c1a5-4c2e-81f2-7c15e493bec8"), new Guid("c4824a81-6996-41a6-bf31-95dc69266175") },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: new Guid("c4824a81-6996-41a6-bf31-95dc69266175"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 9, 7, 0, 20, 13, DateTimeKind.Utc).AddTicks(1156));
        }
    }
}
