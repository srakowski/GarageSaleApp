using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageSaleApp.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GarageSaleEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageSaleEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<int>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_GarageSaleEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "GarageSaleEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GarageSaleEventParties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<int>(nullable: true),
                    PartyId = table.Column<int>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageSaleEventParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GarageSaleEventParties_GarageSaleEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "GarageSaleEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GarageSaleEventParties_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleLineItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaleId = table.Column<int>(nullable: true),
                    PartyId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleLineItems_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleLineItems_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventPartyId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payouts_GarageSaleEventParties_EventPartyId",
                        column: x => x.EventPartyId,
                        principalTable: "GarageSaleEventParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GarageSaleEventParties_EventId",
                table: "GarageSaleEventParties",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_GarageSaleEventParties_PartyId",
                table: "GarageSaleEventParties",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_EventPartyId",
                table: "Payouts",
                column: "EventPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleLineItems_PartyId",
                table: "SaleLineItems",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleLineItems_SaleId",
                table: "SaleLineItems",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EventId",
                table: "Sales",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payouts");

            migrationBuilder.DropTable(
                name: "SaleLineItems");

            migrationBuilder.DropTable(
                name: "GarageSaleEventParties");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "GarageSaleEvents");
        }
    }
}
