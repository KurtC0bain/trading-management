using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TM.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class reform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "074f7937-0dd3-4349-9896-94a1e57f2c9a", "2a1a37eb-2efe-46f1-879d-2236c0f38331" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "2a2beebc-6acb-4112-a527-de638e47ac73", "2a1a37eb-2efe-46f1-879d-2236c0f38331" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "594383d9-a4ea-440d-91ad-c081427eca03", "2a1a37eb-2efe-46f1-879d-2236c0f38331" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "074f7937-0dd3-4349-9896-94a1e57f2c9a", "53e794a6-bf7f-462d-b0e1-80b8380cfcda" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "594383d9-a4ea-440d-91ad-c081427eca03", "53e794a6-bf7f-462d-b0e1-80b8380cfcda" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "2a2beebc-6acb-4112-a527-de638e47ac73", "d8fa67a3-7031-4fbe-aa6d-1193107bede5" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "594383d9-a4ea-440d-91ad-c081427eca03", "d8fa67a3-7031-4fbe-aa6d-1193107bede5" });

            migrationBuilder.DeleteData(
                table: "Pairs",
                keyColumn: "ID",
                keyValue: "0c1c07ba-1bb3-4989-8e49-24e3d35fd262");

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "ID",
                keyValue: "284cd2cd-63ff-46f4-b544-6226d406e4a6");

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "ID",
                keyValue: "87fef7ad-4d02-4c2e-85d7-b3086c923b4c");

            migrationBuilder.DeleteData(
                table: "Factors",
                keyColumn: "ID",
                keyValue: "074f7937-0dd3-4349-9896-94a1e57f2c9a");

            migrationBuilder.DeleteData(
                table: "Factors",
                keyColumn: "ID",
                keyValue: "2a2beebc-6acb-4112-a527-de638e47ac73");

            migrationBuilder.DeleteData(
                table: "Factors",
                keyColumn: "ID",
                keyValue: "594383d9-a4ea-440d-91ad-c081427eca03");

            migrationBuilder.DeleteData(
                table: "Pairs",
                keyColumn: "ID",
                keyValue: "588511af-1559-4aa9-8244-f0ade8db321e");

            migrationBuilder.DeleteData(
                table: "Pairs",
                keyColumn: "ID",
                keyValue: "b82daf79-233a-404a-8f96-64f1502bf48f");

            migrationBuilder.DeleteData(
                table: "Setups",
                keyColumn: "ID",
                keyValue: "2a1a37eb-2efe-46f1-879d-2236c0f38331");

            migrationBuilder.DeleteData(
                table: "Setups",
                keyColumn: "ID",
                keyValue: "53e794a6-bf7f-462d-b0e1-80b8380cfcda");

            migrationBuilder.DeleteData(
                table: "Setups",
                keyColumn: "ID",
                keyValue: "d8fa67a3-7031-4fbe-aa6d-1193107bede5");

            migrationBuilder.AlterColumn<int>(
                name: "ResultType",
                table: "Trades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "RiskAmount",
                table: "Trades",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Factors",
                columns: new[] { "ID", "Description", "Name", "Priority", "UserID" },
                values: new object[,]
                {
                    { "795119c9-8f5b-4fd0-9006-7bcfacdf0700", "Order block", "OB", 1, "9609c3fc-ed25-4c31-b4ea-4e744496bf17" },
                    { "baecda96-5677-4025-9c5b-841d4dc4382e", "Fair value gap", "FVG", 2, "0b20ad6e-4475-4288-8505-c5d34955bbf6" },
                    { "cf9f351a-6e7b-4b82-b213-95dfaa9b9e02", "Break of structure", "BOS", 2, "fbff5bd0-f6fb-4bd8-b77c-04ac939fcd4f" }
                });

            migrationBuilder.InsertData(
                table: "Pairs",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { "395bf86c-a851-4575-b4d5-4607d6477ac4", "BTCUSDT pair", "BTCUSDT" },
                    { "6c8163e2-65df-4c01-9fc6-84858ebc5853", "ETHUSDT pair", "ETHUSDT" },
                    { "8d34d234-e66a-493c-84b5-9b16bc6b91e0", "SOLUSDT pair", "SOLUSDT" }
                });

            migrationBuilder.InsertData(
                table: "Setups",
                columns: new[] { "ID", "Description", "Name", "UserID" },
                values: new object[,]
                {
                    { "286422c6-981c-4e0f-becb-d65b73e358f6", "test 2", "Afternoon", "8fc5a4c4-4a65-4bc1-aab8-c4906a57deb5" },
                    { "93630a77-33c2-4208-8e2d-7b69e1d85438", "test 1", "Morning", "70fc5930-5e10-4ceb-ba06-c5ed8427d143" },
                    { "ac7fd1ce-5679-449c-bbc1-984cf757d269", "test 3", "Evening", "a2befac7-6207-4857-818d-2eba4549617a" }
                });

            migrationBuilder.InsertData(
                table: "FactorSetup",
                columns: new[] { "FactorId", "SetupId" },
                values: new object[,]
                {
                    { "baecda96-5677-4025-9c5b-841d4dc4382e", "286422c6-981c-4e0f-becb-d65b73e358f6" },
                    { "cf9f351a-6e7b-4b82-b213-95dfaa9b9e02", "286422c6-981c-4e0f-becb-d65b73e358f6" },
                    { "795119c9-8f5b-4fd0-9006-7bcfacdf0700", "93630a77-33c2-4208-8e2d-7b69e1d85438" },
                    { "cf9f351a-6e7b-4b82-b213-95dfaa9b9e02", "93630a77-33c2-4208-8e2d-7b69e1d85438" },
                    { "795119c9-8f5b-4fd0-9006-7bcfacdf0700", "ac7fd1ce-5679-449c-bbc1-984cf757d269" },
                    { "baecda96-5677-4025-9c5b-841d4dc4382e", "ac7fd1ce-5679-449c-bbc1-984cf757d269" },
                    { "cf9f351a-6e7b-4b82-b213-95dfaa9b9e02", "ac7fd1ce-5679-449c-bbc1-984cf757d269" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "baecda96-5677-4025-9c5b-841d4dc4382e", "286422c6-981c-4e0f-becb-d65b73e358f6" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "cf9f351a-6e7b-4b82-b213-95dfaa9b9e02", "286422c6-981c-4e0f-becb-d65b73e358f6" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "795119c9-8f5b-4fd0-9006-7bcfacdf0700", "93630a77-33c2-4208-8e2d-7b69e1d85438" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "cf9f351a-6e7b-4b82-b213-95dfaa9b9e02", "93630a77-33c2-4208-8e2d-7b69e1d85438" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "795119c9-8f5b-4fd0-9006-7bcfacdf0700", "ac7fd1ce-5679-449c-bbc1-984cf757d269" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "baecda96-5677-4025-9c5b-841d4dc4382e", "ac7fd1ce-5679-449c-bbc1-984cf757d269" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "cf9f351a-6e7b-4b82-b213-95dfaa9b9e02", "ac7fd1ce-5679-449c-bbc1-984cf757d269" });

            migrationBuilder.DeleteData(
                table: "Pairs",
                keyColumn: "ID",
                keyValue: "395bf86c-a851-4575-b4d5-4607d6477ac4");

            migrationBuilder.DeleteData(
                table: "Pairs",
                keyColumn: "ID",
                keyValue: "6c8163e2-65df-4c01-9fc6-84858ebc5853");

            migrationBuilder.DeleteData(
                table: "Pairs",
                keyColumn: "ID",
                keyValue: "8d34d234-e66a-493c-84b5-9b16bc6b91e0");

            migrationBuilder.DeleteData(
                table: "Factors",
                keyColumn: "ID",
                keyValue: "795119c9-8f5b-4fd0-9006-7bcfacdf0700");

            migrationBuilder.DeleteData(
                table: "Factors",
                keyColumn: "ID",
                keyValue: "baecda96-5677-4025-9c5b-841d4dc4382e");

            migrationBuilder.DeleteData(
                table: "Factors",
                keyColumn: "ID",
                keyValue: "cf9f351a-6e7b-4b82-b213-95dfaa9b9e02");

            migrationBuilder.DeleteData(
                table: "Setups",
                keyColumn: "ID",
                keyValue: "286422c6-981c-4e0f-becb-d65b73e358f6");

            migrationBuilder.DeleteData(
                table: "Setups",
                keyColumn: "ID",
                keyValue: "93630a77-33c2-4208-8e2d-7b69e1d85438");

            migrationBuilder.DeleteData(
                table: "Setups",
                keyColumn: "ID",
                keyValue: "ac7fd1ce-5679-449c-bbc1-984cf757d269");

            migrationBuilder.DropColumn(
                name: "RiskAmount",
                table: "Trades");

            migrationBuilder.AlterColumn<int>(
                name: "ResultType",
                table: "Trades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}
