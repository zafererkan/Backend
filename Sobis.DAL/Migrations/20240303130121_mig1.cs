using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sobis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APP_CLAIM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CLAIM_CODE = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    CLAIM_NAME = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("APP_CLAIM_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "APP_USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    SURNAME = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    PASSWORD = table.Column<string>(type: "character varying(120)", unicode: false, maxLength: 120, nullable: true),
                    TYPE = table.Column<int>(type: "integer", unicode: false, maxLength: 1, nullable: true),
                    EMAIL = table.Column<string>(type: "character varying(60)", unicode: false, maxLength: 60, nullable: true),
                    EMAIL_CONFIRMED = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "H"),
                    PHONE = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    DEFAULT_COMPANY_ID = table.Column<int>(type: "integer", unicode: false, maxLength: 3, nullable: true),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("APP_USER_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "APP_USER_CLAIM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    APP_USER_ID = table.Column<int>(type: "integer", unicode: false, nullable: false),
                    APP_CLAIM_ID = table.Column<int>(type: "integer", unicode: false, nullable: false),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("APP_USER_CLAIM_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PARAMETER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PARAM_NAME = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PARAMETER_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PARAMETER_DETAIL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PARAM_ID = table.Column<int>(type: "integer", unicode: false, nullable: false),
                    PARAM_DETAIL_NAME = table.Column<string>(type: "character varying(60)", unicode: false, maxLength: 60, nullable: false),
                    PARENT_DATA_ID = table.Column<int>(type: "integer", unicode: false, nullable: true),
                    DATA = table.Column<int>(type: "integer", unicode: false, nullable: false),
                    DATA_VALUE = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    ORDER_NO = table.Column<int>(type: "integer", unicode: false, nullable: true),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PARAMETER_DETAIL_PK", x => x.ID);
                    table.ForeignKey(
                        name: "PARAMETER_DETAIL_FK1",
                        column: x => x.PARAM_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "APP_CLAIM",
                columns: new[] { "ID", "CLAIM_CODE", "CLAIM_NAME", "CR_DATE", "CR_USER", "MOD_DATE", "MOD_USER" },
                values: new object[,]
                {
                    { 1, "admin", "Sistem Yöneticisi", new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1925), null, new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1933), null },
                    { 2, "editor", "Editör", new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1936), null, new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1936), null },
                    { 3, "user", "user", new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1937), null, new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1937), null }
                });

            migrationBuilder.InsertData(
                table: "APP_USER",
                columns: new[] { "ID", "CR_DATE", "CR_USER", "DEFAULT_COMPANY_ID", "EMAIL", "EMAIL_CONFIRMED", "MOD_DATE", "MOD_USER", "NAME", "PASSWORD", "PHONE", "STATUS", "SURNAME", "TYPE" },
                values: new object[] { 1, new DateTime(2024, 3, 3, 16, 1, 21, 317, DateTimeKind.Local).AddTicks(3280), null, null, "SRDR", "E", new DateTime(2024, 3, 3, 16, 1, 21, 317, DateTimeKind.Local).AddTicks(3283), null, "Serdar", "R6vvE51wrwp4yAo2Ld+VdQ==", "0535 647 39 71", "E", "ÖZDEMİR", 3 });

            migrationBuilder.InsertData(
                table: "APP_USER_CLAIM",
                columns: new[] { "ID", "APP_CLAIM_ID", "APP_USER_ID", "CR_DATE", "CR_USER", "MOD_DATE", "MOD_USER" },
                values: new object[] { 1, 1, 1, new DateTime(2024, 3, 3, 16, 1, 21, 316, DateTimeKind.Local).AddTicks(418), null, new DateTime(2024, 3, 3, 16, 1, 21, 316, DateTimeKind.Local).AddTicks(421), null });

            migrationBuilder.CreateIndex(
                name: "APP_CLAIM_UK1",
                table: "APP_CLAIM",
                column: "CLAIM_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "APP_USER_UK1",
                table: "APP_USER",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "APP_USER_UK2",
                table: "APP_USER",
                column: "PHONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "APP_USER_X1",
                table: "APP_USER",
                columns: new[] { "EMAIL", "PASSWORD" });

            migrationBuilder.CreateIndex(
                name: "APP_USER_X2",
                table: "APP_USER",
                columns: new[] { "PHONE", "PASSWORD" });

            migrationBuilder.CreateIndex(
                name: "APP_USER_CLAIM_X1",
                table: "APP_USER_CLAIM",
                column: "APP_USER_ID");

            migrationBuilder.CreateIndex(
                name: "APP_USER_CLAIM_X2",
                table: "APP_USER_CLAIM",
                column: "APP_CLAIM_ID");

            migrationBuilder.CreateIndex(
                name: "PARAMETER_DETAIL_X1",
                table: "PARAMETER_DETAIL",
                column: "PARAM_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APP_CLAIM");

            migrationBuilder.DropTable(
                name: "APP_USER");

            migrationBuilder.DropTable(
                name: "APP_USER_CLAIM");

            migrationBuilder.DropTable(
                name: "PARAMETER_DETAIL");

            migrationBuilder.DropTable(
                name: "PARAMETER");
        }
    }
}
