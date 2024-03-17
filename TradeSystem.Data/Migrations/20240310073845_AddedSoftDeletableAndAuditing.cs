using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class AddedSoftDeletableAndAuditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Trades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Trades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Trades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TradeOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TradeOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "TradeOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Towns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Towns",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Towns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Towns",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "IdentityDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "IdentityDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FinancialInstruments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "FinancialInstruments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FinancialInstruments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "FinancialInstruments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Divisions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Divisions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "DepositedMoney",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DepositedMoney",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "DepositedMoney",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "DataOfIndividualClients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "DataOfCorporateClients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ClientFinancialInstruments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ClientFinancialInstruments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ClientFinancialInstruments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ClientFinancialInstruments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Adminstrators",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Adminstrators",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Adminstrators",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Adminstrators",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TradeOrders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TradeOrders");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "TradeOrders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Towns");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "IdentityDocuments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "IdentityDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FinancialInstruments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "FinancialInstruments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FinancialInstruments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "FinancialInstruments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "DepositedMoney");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DepositedMoney");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "DepositedMoney");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "DataOfCorporateClients");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ClientFinancialInstruments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ClientFinancialInstruments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ClientFinancialInstruments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ClientFinancialInstruments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Adminstrators");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Adminstrators");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Adminstrators");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Adminstrators");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Addresses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "379565d5-1775-4808-9a96-06864d2fc0a5", "AQAAAAEAACcQAAAAEIckdSvPKrIk+BlwXRTTwSg80oaZy8HgqD55Eu7GgJ9P+wOknzTbi+3ehF6p/7xwGg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb90a07d-266d-4eba-a631-44ef85682c63", "AQAAAAEAACcQAAAAECQ64POPDVqyn7VheJk8oPmJh74zTf6r9Rnd3nr8wQ2glA8rJx59/tcXf5lhu8TfBQ==" });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 9, 21, 0, 2, 916, DateTimeKind.Local).AddTicks(4584));
        }
    }
}
