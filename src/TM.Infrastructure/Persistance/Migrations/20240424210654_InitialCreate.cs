using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pairs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Setups",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FactorSetup",
                columns: table => new
                {
                    FactorsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetupsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorSetup", x => new { x.FactorsID, x.SetupsID });
                    table.ForeignKey(
                        name: "FK_FactorSetup_Factors_FactorsID",
                        column: x => x.FactorsID,
                        principalTable: "Factors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactorSetup_Setups_SetupsID",
                        column: x => x.SetupsID,
                        principalTable: "Setups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PositionType = table.Column<int>(type: "int", nullable: false),
                    DirectionType = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    BudgetRisk = table.Column<double>(type: "float", nullable: false),
                    RiskRevardRatio = table.Column<double>(type: "float", nullable: false),
                    ResultType = table.Column<int>(type: "int", nullable: false),
                    Profit = table.Column<double>(type: "float", nullable: false),
                    SetupID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PairID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trades_Pairs_PairID",
                        column: x => x.PairID,
                        principalTable: "Pairs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trades_Setups_SetupID",
                        column: x => x.SetupID,
                        principalTable: "Setups",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FactorTrade",
                columns: table => new
                {
                    FactorsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorTrade", x => new { x.FactorsID, x.TradesID });
                    table.ForeignKey(
                        name: "FK_FactorTrade_Factors_FactorsID",
                        column: x => x.FactorsID,
                        principalTable: "Factors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactorTrade_Trades_TradesID",
                        column: x => x.TradesID,
                        principalTable: "Trades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactorSetup_SetupsID",
                table: "FactorSetup",
                column: "SetupsID");

            migrationBuilder.CreateIndex(
                name: "IX_FactorTrade_TradesID",
                table: "FactorTrade",
                column: "TradesID");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_PairID",
                table: "Trades",
                column: "PairID");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_SetupID",
                table: "Trades",
                column: "SetupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactorSetup");

            migrationBuilder.DropTable(
                name: "FactorTrade");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Pairs");

            migrationBuilder.DropTable(
                name: "Setups");
        }
    }
}
