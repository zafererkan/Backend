using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sobis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SUB_CATEGORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CATEGORY_ID = table.Column<int>(type: "integer", unicode: false, nullable: false),
                    SUB_CATEGORY_NAME = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("SUB_CATEGORY_PK", x => x.ID);
                    table.ForeignKey(
                        name: "SUB_CATEGORY_FK1",
                        column: x => x.CATEGORY_ID,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 22, 36, 29, 151, DateTimeKind.Local).AddTicks(2565), new DateTime(2024, 4, 5, 22, 36, 29, 151, DateTimeKind.Local).AddTicks(2575) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 22, 36, 29, 151, DateTimeKind.Local).AddTicks(2578), new DateTime(2024, 4, 5, 22, 36, 29, 151, DateTimeKind.Local).AddTicks(2578) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 22, 36, 29, 151, DateTimeKind.Local).AddTicks(2579), new DateTime(2024, 4, 5, 22, 36, 29, 151, DateTimeKind.Local).AddTicks(2579) });

            migrationBuilder.UpdateData(
                table: "APP_USER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 22, 36, 29, 154, DateTimeKind.Local).AddTicks(3310), new DateTime(2024, 4, 5, 22, 36, 29, 154, DateTimeKind.Local).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "APP_USER_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 22, 36, 29, 152, DateTimeKind.Local).AddTicks(4748), new DateTime(2024, 4, 5, 22, 36, 29, 152, DateTimeKind.Local).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "PARAMETER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 22, 36, 29, 166, DateTimeKind.Local).AddTicks(4364), new DateTime(2024, 4, 5, 22, 36, 29, 166, DateTimeKind.Local).AddTicks(4367) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 22, 36, 29, 166, DateTimeKind.Local).AddTicks(1465), new DateTime(2024, 4, 5, 22, 36, 29, 166, DateTimeKind.Local).AddTicks(1475) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 22, 36, 29, 166, DateTimeKind.Local).AddTicks(1479), new DateTime(2024, 4, 5, 22, 36, 29, 166, DateTimeKind.Local).AddTicks(1479) });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_SUBCATEGORY_ID",
                table: "PRODUCT",
                column: "SUBCATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUB_CATEGORY_CATEGORY_ID",
                table: "SUB_CATEGORY",
                column: "CATEGORY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_SUB_CATEGORY_SUBCATEGORY_ID",
                table: "PRODUCT",
                column: "SUBCATEGORY_ID",
                principalTable: "SUB_CATEGORY",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_SUB_CATEGORY_SUBCATEGORY_ID",
                table: "PRODUCT");

            migrationBuilder.DropTable(
                name: "SUB_CATEGORY");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_SUBCATEGORY_ID",
                table: "PRODUCT");

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 12, 43, 155, DateTimeKind.Local).AddTicks(5472), new DateTime(2024, 3, 25, 23, 12, 43, 155, DateTimeKind.Local).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 12, 43, 155, DateTimeKind.Local).AddTicks(5483), new DateTime(2024, 3, 25, 23, 12, 43, 155, DateTimeKind.Local).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 12, 43, 155, DateTimeKind.Local).AddTicks(5485), new DateTime(2024, 3, 25, 23, 12, 43, 155, DateTimeKind.Local).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "APP_USER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 12, 43, 157, DateTimeKind.Local).AddTicks(9688), new DateTime(2024, 3, 25, 23, 12, 43, 157, DateTimeKind.Local).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "APP_USER_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 12, 43, 156, DateTimeKind.Local).AddTicks(5116), new DateTime(2024, 3, 25, 23, 12, 43, 156, DateTimeKind.Local).AddTicks(5119) });

            migrationBuilder.UpdateData(
                table: "PARAMETER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 12, 43, 166, DateTimeKind.Local).AddTicks(2317), new DateTime(2024, 3, 25, 23, 12, 43, 166, DateTimeKind.Local).AddTicks(2320) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 12, 43, 165, DateTimeKind.Local).AddTicks(9252), new DateTime(2024, 3, 25, 23, 12, 43, 165, DateTimeKind.Local).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 23, 12, 43, 165, DateTimeKind.Local).AddTicks(9269), new DateTime(2024, 3, 25, 23, 12, 43, 165, DateTimeKind.Local).AddTicks(9269) });
        }
    }
}
