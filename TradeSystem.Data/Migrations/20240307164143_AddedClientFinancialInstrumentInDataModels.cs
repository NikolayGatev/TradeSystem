using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class AddedClientFinancialInstrumentInDataModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientFinancialInstruments",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialInstrumentId = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFinancialInstruments", x => new { x.FinancialInstrumentId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_ClientFinancialInstruments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFinancialInstruments_FinancialInstruments_FinancialInstrumentId",
                        column: x => x.FinancialInstrumentId,
                        principalTable: "FinancialInstruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFinancialInstruments_ClientId",
                table: "ClientFinancialInstruments",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFinancialInstruments");
        }
    }
}
