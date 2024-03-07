using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class RemoveClientFromDataOfIndividualAndCorporativeClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataOfCorporateClients_Clients_ClientId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DataOfIndividualClients_Clients_ClientId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfIndividualClients_ClientId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropIndex(
                name: "IX_DataOfCorporateClients_ClientId",
                table: "DataOfCorporateClients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "DataOfIndividualClients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "DataOfCorporateClients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "DataOfIndividualClients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "DataOfCorporateClients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataOfIndividualClients_ClientId",
                table: "DataOfIndividualClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DataOfCorporateClients_ClientId",
                table: "DataOfCorporateClients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfCorporateClients_Clients_ClientId",
                table: "DataOfCorporateClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataOfIndividualClients_Clients_ClientId",
                table: "DataOfIndividualClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
