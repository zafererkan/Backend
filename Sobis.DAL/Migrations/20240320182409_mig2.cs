using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sobis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PRODUCT_NAME = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: false),
                    CATEGORY_ID = table.Column<int>(type: "integer", unicode: false, nullable: false),
                    SUBCATEGORY_ID = table.Column<int>(type: "integer", unicode: false, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true),
                    MIN_BUDGET = table.Column<int>(type: "integer", unicode: false, nullable: true),
                    MAX_BUDGET = table.Column<int>(type: "integer", unicode: false, nullable: true),
                    CITY_ID = table.Column<int>(type: "integer", unicode: false, nullable: true),
                    DISTRICT_ID = table.Column<int>(type: "integer", unicode: false, nullable: true),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRODUCT_PK", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 24, 9, 435, DateTimeKind.Local).AddTicks(6109), new DateTime(2024, 3, 20, 21, 24, 9, 435, DateTimeKind.Local).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 24, 9, 435, DateTimeKind.Local).AddTicks(6124), new DateTime(2024, 3, 20, 21, 24, 9, 435, DateTimeKind.Local).AddTicks(6124) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 24, 9, 435, DateTimeKind.Local).AddTicks(6126), new DateTime(2024, 3, 20, 21, 24, 9, 435, DateTimeKind.Local).AddTicks(6127) });

            migrationBuilder.UpdateData(
                table: "APP_USER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 24, 9, 439, DateTimeKind.Local).AddTicks(3141), new DateTime(2024, 3, 20, 21, 24, 9, 439, DateTimeKind.Local).AddTicks(3146) });

            migrationBuilder.UpdateData(
                table: "APP_USER_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 24, 9, 437, DateTimeKind.Local).AddTicks(626), new DateTime(2024, 3, 20, 21, 24, 9, 437, DateTimeKind.Local).AddTicks(631) });

            migrationBuilder.CreateIndex(
                name: "PRODUCT_X1",
                table: "PRODUCT",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "PRODUCT_X2",
                table: "PRODUCT",
                column: "PRODUCT_NAME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1925), new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1933) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1936), new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1936) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1937), new DateTime(2024, 3, 3, 16, 1, 21, 315, DateTimeKind.Local).AddTicks(1937) });

            migrationBuilder.UpdateData(
                table: "APP_USER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 3, 16, 1, 21, 317, DateTimeKind.Local).AddTicks(3280), new DateTime(2024, 3, 3, 16, 1, 21, 317, DateTimeKind.Local).AddTicks(3283) });

            migrationBuilder.UpdateData(
                table: "APP_USER_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 3, 16, 1, 21, 316, DateTimeKind.Local).AddTicks(418), new DateTime(2024, 3, 3, 16, 1, 21, 316, DateTimeKind.Local).AddTicks(421) });
        }
    }
}
