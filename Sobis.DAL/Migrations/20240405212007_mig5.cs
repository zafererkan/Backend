using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sobis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_PRODUCT_SUB_CATEGORY_ID",
                table: "PRODUCT",
                newName: "PRODUCT_X3");

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PLATE_NO = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: true),
                    CITY_NAME = table.Column<string>(type: "character varying(60)", unicode: false, maxLength: 60, nullable: false),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("CITY_PK", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5035), new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5044) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5047), new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5047) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5048), new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "APP_USER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 20, 7, 265, DateTimeKind.Local).AddTicks(1030), new DateTime(2024, 4, 6, 0, 20, 7, 265, DateTimeKind.Local).AddTicks(1033) });

            migrationBuilder.UpdateData(
                table: "APP_USER_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 20, 7, 263, DateTimeKind.Local).AddTicks(5244), new DateTime(2024, 4, 6, 0, 20, 7, 263, DateTimeKind.Local).AddTicks(5247) });

            migrationBuilder.UpdateData(
                table: "PARAMETER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(7663), new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(7666) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(4954), new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(4967), new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(4968) });

            migrationBuilder.CreateIndex(
                name: "CITY_X1",
                table: "CITY",
                column: "PLATE_NO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.RenameIndex(
                name: "PRODUCT_X3",
                table: "PRODUCT",
                newName: "IX_PRODUCT_SUB_CATEGORY_ID");

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 11, 42, 476, DateTimeKind.Local).AddTicks(7334), new DateTime(2024, 4, 5, 23, 11, 42, 476, DateTimeKind.Local).AddTicks(7343) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 11, 42, 476, DateTimeKind.Local).AddTicks(7345), new DateTime(2024, 4, 5, 23, 11, 42, 476, DateTimeKind.Local).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 11, 42, 476, DateTimeKind.Local).AddTicks(7347), new DateTime(2024, 4, 5, 23, 11, 42, 476, DateTimeKind.Local).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "APP_USER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 11, 42, 479, DateTimeKind.Local).AddTicks(3498), new DateTime(2024, 4, 5, 23, 11, 42, 479, DateTimeKind.Local).AddTicks(3501) });

            migrationBuilder.UpdateData(
                table: "APP_USER_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 11, 42, 477, DateTimeKind.Local).AddTicks(7692), new DateTime(2024, 4, 5, 23, 11, 42, 477, DateTimeKind.Local).AddTicks(7696) });

            migrationBuilder.UpdateData(
                table: "PARAMETER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 11, 42, 489, DateTimeKind.Local).AddTicks(7972), new DateTime(2024, 4, 5, 23, 11, 42, 489, DateTimeKind.Local).AddTicks(7975) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 11, 42, 489, DateTimeKind.Local).AddTicks(5328), new DateTime(2024, 4, 5, 23, 11, 42, 489, DateTimeKind.Local).AddTicks(5333) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 11, 42, 489, DateTimeKind.Local).AddTicks(5336), new DateTime(2024, 4, 5, 23, 11, 42, 489, DateTimeKind.Local).AddTicks(5336) });
        }
    }
}
