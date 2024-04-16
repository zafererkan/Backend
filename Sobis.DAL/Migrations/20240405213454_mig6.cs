using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sobis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DISTRICT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CITY_ID = table.Column<int>(type: "integer", unicode: false, precision: 2, nullable: false),
                    DISTRICT_NAME = table.Column<string>(type: "character varying(60)", unicode: false, maxLength: 60, nullable: false),
                    CR_USER = table.Column<int>(type: "integer", nullable: true),
                    CR_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MOD_USER = table.Column<int>(type: "integer", nullable: true),
                    MOD_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    STATUS = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true, defaultValue: "E")
                },
                constraints: table =>
                {
                    table.PrimaryKey("DISTRICT_PK", x => x.ID);
                    table.ForeignKey(
                        name: "DISTRICT_FK1",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 34, 53, 926, DateTimeKind.Local).AddTicks(2699), new DateTime(2024, 4, 6, 0, 34, 53, 926, DateTimeKind.Local).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 34, 53, 926, DateTimeKind.Local).AddTicks(2712), new DateTime(2024, 4, 6, 0, 34, 53, 926, DateTimeKind.Local).AddTicks(2713) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 34, 53, 926, DateTimeKind.Local).AddTicks(2714), new DateTime(2024, 4, 6, 0, 34, 53, 926, DateTimeKind.Local).AddTicks(2714) });

            migrationBuilder.UpdateData(
                table: "APP_USER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 34, 53, 928, DateTimeKind.Local).AddTicks(7113), new DateTime(2024, 4, 6, 0, 34, 53, 928, DateTimeKind.Local).AddTicks(7116) });

            migrationBuilder.UpdateData(
                table: "APP_USER_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 34, 53, 927, DateTimeKind.Local).AddTicks(2731), new DateTime(2024, 4, 6, 0, 34, 53, 927, DateTimeKind.Local).AddTicks(2737) });

            migrationBuilder.UpdateData(
                table: "PARAMETER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 34, 53, 941, DateTimeKind.Local).AddTicks(8932), new DateTime(2024, 4, 6, 0, 34, 53, 941, DateTimeKind.Local).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 34, 53, 941, DateTimeKind.Local).AddTicks(5674), new DateTime(2024, 4, 6, 0, 34, 53, 941, DateTimeKind.Local).AddTicks(5683) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 6, 0, 34, 53, 941, DateTimeKind.Local).AddTicks(5687), new DateTime(2024, 4, 6, 0, 34, 53, 941, DateTimeKind.Local).AddTicks(5687) });

            migrationBuilder.CreateIndex(
                name: "DISTRICT_X1",
                table: "DISTRICT",
                column: "CITY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DISTRICT");

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
        }
    }
}
