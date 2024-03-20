using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class ChanchClientWhitApplicationUserAtIdentityDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityDocuments_Clients_ClientId",
                table: "IdentityDocuments");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "IdentityDocuments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityDocuments_ClientId",
                table: "IdentityDocuments",
                newName: "IX_IdentityDocuments_UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityDocuments_AspNetUsers_UserId",
                table: "IdentityDocuments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityDocuments_AspNetUsers_UserId",
                table: "IdentityDocuments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "IdentityDocuments",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityDocuments_UserId",
                table: "IdentityDocuments",
                newName: "IX_IdentityDocuments_ClientId");

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

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 19, 21, 51, 32, 202, DateTimeKind.Local).AddTicks(7794));

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityDocuments_Clients_ClientId",
                table: "IdentityDocuments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
