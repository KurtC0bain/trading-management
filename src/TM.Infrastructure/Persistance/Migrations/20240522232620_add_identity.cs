using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TM.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class add_identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Factors",
                columns: new[] { "ID", "Description", "Name", "Priority", "UserID" },
                values: new object[,]
                {
                    { "2225482d-c1e9-4645-93fa-52d6a0d5e3e1", "Fair value gap", "FVG", 2, "dc4c55b1-29f7-4a94-bbcc-bf66175f3139" },
                    { "bb17b8c9-f952-4bc5-8ee0-6c3cacf7f3cd", "Order block", "OB", 1, "b5401462-8ad7-4ef4-9dba-e7c0af483068" },
                    { "f6ef8223-74bf-41f3-9591-88ab1637a799", "Break of structure", "BOS", 2, "6ac7ace0-b449-45a2-9ecd-c5efc8bb56e7" }
                });

            migrationBuilder.InsertData(
                table: "Pairs",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { "424b176f-0977-46a4-a843-7163d0de5050", "BTCUSDT pair", "BTCUSDT" },
                    { "7bf9f125-3a27-4e6c-9f52-6a68673dd1ad", "SOLUSDT pair", "SOLUSDT" },
                    { "e9181128-28e2-4acb-995b-c3f0405c5d64", "ETHUSDT pair", "ETHUSDT" }
                });

            migrationBuilder.InsertData(
                table: "Setups",
                columns: new[] { "ID", "Description", "Name", "UserID" },
                values: new object[,]
                {
                    { "2b5103be-3857-43a3-a89c-7cd0a679fcd6", "test 3", "Evening", "3bad7a07-a181-4d54-b4b7-41c15363e114" },
                    { "a6aab8ec-e896-4cc0-96fa-88686aad4dcf", "test 2", "Afternoon", "ebc1ad7d-0443-4717-8fef-5f63cc406316" },
                    { "acb559d1-6e59-424c-bdeb-0c5a3bb5acc3", "test 1", "Morning", "f3a062ef-f515-4dfc-8eb4-3d261c767f72" }
                });

            migrationBuilder.InsertData(
                table: "FactorSetup",
                columns: new[] { "FactorId", "SetupId" },
                values: new object[,]
                {
                    { "2225482d-c1e9-4645-93fa-52d6a0d5e3e1", "2b5103be-3857-43a3-a89c-7cd0a679fcd6" },
                    { "bb17b8c9-f952-4bc5-8ee0-6c3cacf7f3cd", "2b5103be-3857-43a3-a89c-7cd0a679fcd6" },
                    { "f6ef8223-74bf-41f3-9591-88ab1637a799", "2b5103be-3857-43a3-a89c-7cd0a679fcd6" },
                    { "2225482d-c1e9-4645-93fa-52d6a0d5e3e1", "a6aab8ec-e896-4cc0-96fa-88686aad4dcf" },
                    { "f6ef8223-74bf-41f3-9591-88ab1637a799", "a6aab8ec-e896-4cc0-96fa-88686aad4dcf" },
                    { "bb17b8c9-f952-4bc5-8ee0-6c3cacf7f3cd", "acb559d1-6e59-424c-bdeb-0c5a3bb5acc3" },
                    { "f6ef8223-74bf-41f3-9591-88ab1637a799", "acb559d1-6e59-424c-bdeb-0c5a3bb5acc3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "2225482d-c1e9-4645-93fa-52d6a0d5e3e1", "2b5103be-3857-43a3-a89c-7cd0a679fcd6" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "bb17b8c9-f952-4bc5-8ee0-6c3cacf7f3cd", "2b5103be-3857-43a3-a89c-7cd0a679fcd6" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "f6ef8223-74bf-41f3-9591-88ab1637a799", "2b5103be-3857-43a3-a89c-7cd0a679fcd6" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "2225482d-c1e9-4645-93fa-52d6a0d5e3e1", "a6aab8ec-e896-4cc0-96fa-88686aad4dcf" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "f6ef8223-74bf-41f3-9591-88ab1637a799", "a6aab8ec-e896-4cc0-96fa-88686aad4dcf" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "bb17b8c9-f952-4bc5-8ee0-6c3cacf7f3cd", "acb559d1-6e59-424c-bdeb-0c5a3bb5acc3" });

            migrationBuilder.DeleteData(
                table: "FactorSetup",
                keyColumns: new[] { "FactorId", "SetupId" },
                keyValues: new object[] { "f6ef8223-74bf-41f3-9591-88ab1637a799", "acb559d1-6e59-424c-bdeb-0c5a3bb5acc3" });

            migrationBuilder.DeleteData(
                table: "Pairs",
                keyColumn: "ID",
                keyValue: "424b176f-0977-46a4-a843-7163d0de5050");

            migrationBuilder.DeleteData(
                table: "Pairs",
                keyColumn: "ID",
                keyValue: "7bf9f125-3a27-4e6c-9f52-6a68673dd1ad");

            migrationBuilder.DeleteData(
                table: "Pairs",
                keyColumn: "ID",
                keyValue: "e9181128-28e2-4acb-995b-c3f0405c5d64");

            migrationBuilder.DeleteData(
                table: "Factors",
                keyColumn: "ID",
                keyValue: "2225482d-c1e9-4645-93fa-52d6a0d5e3e1");

            migrationBuilder.DeleteData(
                table: "Factors",
                keyColumn: "ID",
                keyValue: "bb17b8c9-f952-4bc5-8ee0-6c3cacf7f3cd");

            migrationBuilder.DeleteData(
                table: "Factors",
                keyColumn: "ID",
                keyValue: "f6ef8223-74bf-41f3-9591-88ab1637a799");

            migrationBuilder.DeleteData(
                table: "Setups",
                keyColumn: "ID",
                keyValue: "2b5103be-3857-43a3-a89c-7cd0a679fcd6");

            migrationBuilder.DeleteData(
                table: "Setups",
                keyColumn: "ID",
                keyValue: "a6aab8ec-e896-4cc0-96fa-88686aad4dcf");

            migrationBuilder.DeleteData(
                table: "Setups",
                keyColumn: "ID",
                keyValue: "acb559d1-6e59-424c-bdeb-0c5a3bb5acc3");

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
    }
}
