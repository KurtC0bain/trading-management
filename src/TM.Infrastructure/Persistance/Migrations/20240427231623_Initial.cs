using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TM.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    SetupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FactorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorSetup", x => new { x.SetupId, x.FactorId });
                    table.ForeignKey(
                        name: "FK_FactorSetup_Factors_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactorSetup_Setups_SetupId",
                        column: x => x.SetupId,
                        principalTable: "Setups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetupID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PairID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InitialDeposit = table.Column<double>(type: "float", nullable: false),
                    PriceEntry = table.Column<double>(type: "float", nullable: false),
                    PriceStop = table.Column<double>(type: "float", nullable: false),
                    PriceTake = table.Column<double>(type: "float", nullable: false),
                    Profit = table.Column<double>(type: "float", nullable: false),
                    DepositRisk = table.Column<double>(type: "float", nullable: false),
                    RiskRewardRatio = table.Column<double>(type: "float", nullable: false),
                    PositionType = table.Column<int>(type: "int", nullable: false),
                    DirectionType = table.Column<int>(type: "int", nullable: false),
                    ResultType = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Factors",
                columns: new[] { "ID", "Description", "Name", "Priority", "UserID" },
                values: new object[,]
                {
                    { "074f7937-0dd3-4349-9896-94a1e57f2c9a", "Fair value gap", "FVG", 2, "546ab7d4-a4d5-4270-a6f6-c48a30aeb275" },
                    { "2a2beebc-6acb-4112-a527-de638e47ac73", "Order block", "OB", 1, "0ee200cc-eff4-469e-90b2-866bd2d818e0" },
                    { "594383d9-a4ea-440d-91ad-c081427eca03", "Break of structure", "BOS", 2, "26975d5d-3138-4a94-baff-56f045796c42" }
                });

            migrationBuilder.InsertData(
                table: "Pairs",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { "0c1c07ba-1bb3-4989-8e49-24e3d35fd262", "SOLUSDT pair", "SOLUSDT" },
                    { "588511af-1559-4aa9-8244-f0ade8db321e", "BTCUSDT pair", "BTCUSDT" },
                    { "b82daf79-233a-404a-8f96-64f1502bf48f", "ETHUSDT pair", "ETHUSDT" }
                });

            migrationBuilder.InsertData(
                table: "Setups",
                columns: new[] { "ID", "Description", "Name", "UserID" },
                values: new object[,]
                {
                    { "2a1a37eb-2efe-46f1-879d-2236c0f38331", "test 3", "Evening", "5e5947d9-9116-4f20-aeea-0269550898f7" },
                    { "53e794a6-bf7f-462d-b0e1-80b8380cfcda", "test 2", "Afternoon", "48617856-fbdf-4f88-b2e7-05256c17bb0b" },
                    { "d8fa67a3-7031-4fbe-aa6d-1193107bede5", "test 1", "Morning", "3fca17cd-eba9-4165-80c0-9f8a1f0906b3" }
                });

            migrationBuilder.InsertData(
                table: "FactorSetup",
                columns: new[] { "FactorId", "SetupId" },
                values: new object[,]
                {
                    { "074f7937-0dd3-4349-9896-94a1e57f2c9a", "2a1a37eb-2efe-46f1-879d-2236c0f38331" },
                    { "2a2beebc-6acb-4112-a527-de638e47ac73", "2a1a37eb-2efe-46f1-879d-2236c0f38331" },
                    { "594383d9-a4ea-440d-91ad-c081427eca03", "2a1a37eb-2efe-46f1-879d-2236c0f38331" },
                    { "074f7937-0dd3-4349-9896-94a1e57f2c9a", "53e794a6-bf7f-462d-b0e1-80b8380cfcda" },
                    { "594383d9-a4ea-440d-91ad-c081427eca03", "53e794a6-bf7f-462d-b0e1-80b8380cfcda" },
                    { "2a2beebc-6acb-4112-a527-de638e47ac73", "d8fa67a3-7031-4fbe-aa6d-1193107bede5" },
                    { "594383d9-a4ea-440d-91ad-c081427eca03", "d8fa67a3-7031-4fbe-aa6d-1193107bede5" }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "ID", "Date", "DepositRisk", "DirectionType", "InitialDeposit", "PairID", "PositionType", "PriceEntry", "PriceStop", "PriceTake", "Profit", "Rating", "ResultType", "RiskRewardRatio", "SetupID", "UserID" },
                values: new object[,]
                {
                    { "284cd2cd-63ff-46f4-b544-6226d406e4a6", new DateTime(2024, 4, 28, 2, 16, 23, 347, DateTimeKind.Local).AddTicks(458), 2.0, 1, 500.0, "b82daf79-233a-404a-8f96-64f1502bf48f", 1, 3200.0, 3225.0, 3150.0, 2000.0, 3, 1, 2.0, "2a1a37eb-2efe-46f1-879d-2236c0f38331", "d5294903-fbd0-499b-acca-ba9d12a4184d" },
                    { "87fef7ad-4d02-4c2e-85d7-b3086c923b4c", new DateTime(2024, 4, 28, 2, 16, 23, 347, DateTimeKind.Local).AddTicks(404), 2.0, 0, 500.0, "588511af-1559-4aa9-8244-f0ade8db321e", 0, 60000.0, 59900.0, 60500.0, 4999.9999999998681, 4, 0, 5.0, "d8fa67a3-7031-4fbe-aa6d-1193107bede5", "c1ac02bb-0087-46bb-aae2-120b6d7d71e7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactorSetup_FactorId",
                table: "FactorSetup",
                column: "FactorId");

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
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DropTable(
                name: "Pairs");

            migrationBuilder.DropTable(
                name: "Setups");
        }
    }
}
