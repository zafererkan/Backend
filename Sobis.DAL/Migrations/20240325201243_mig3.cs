using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sobis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("CATEGORY_PK", x => x.ID);
                });

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

            migrationBuilder.AddForeignKey(
                name: "PRODUCT_FK1",
                table: "PRODUCT",
                column: "CATEGORY_ID",
                principalTable: "CATEGORY",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PRODUCT_FK1",
                table: "PRODUCT");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 22, 23, 46, 603, DateTimeKind.Local).AddTicks(6785), new DateTime(2024, 3, 25, 22, 23, 46, 603, DateTimeKind.Local).AddTicks(6794) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 22, 23, 46, 603, DateTimeKind.Local).AddTicks(6796), new DateTime(2024, 3, 25, 22, 23, 46, 603, DateTimeKind.Local).AddTicks(6797) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 22, 23, 46, 603, DateTimeKind.Local).AddTicks(6798), new DateTime(2024, 3, 25, 22, 23, 46, 603, DateTimeKind.Local).AddTicks(6798) });

            migrationBuilder.UpdateData(
                table: "APP_USER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 22, 23, 46, 606, DateTimeKind.Local).AddTicks(971), new DateTime(2024, 3, 25, 22, 23, 46, 606, DateTimeKind.Local).AddTicks(973) });

            migrationBuilder.UpdateData(
                table: "APP_USER_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 22, 23, 46, 604, DateTimeKind.Local).AddTicks(6550), new DateTime(2024, 3, 25, 22, 23, 46, 604, DateTimeKind.Local).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "PARAMETER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(9814), new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(9817) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(7122), new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(7133), new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(7133) });
        }
    }
}
