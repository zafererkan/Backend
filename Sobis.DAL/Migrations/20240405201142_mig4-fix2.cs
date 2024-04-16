using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sobis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig4fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SUBCATEGORY_ID",
                table: "PRODUCT",
                newName: "SUB_CATEGORY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCT_SUBCATEGORY_ID",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SUB_CATEGORY_ID",
                table: "PRODUCT",
                newName: "SUBCATEGORY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCT_SUB_CATEGORY_ID",
                table: "PRODUCT",
                newName: "IX_PRODUCT_SUBCATEGORY_ID");

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 5, 20, 153, DateTimeKind.Local).AddTicks(5431), new DateTime(2024, 4, 5, 23, 5, 20, 153, DateTimeKind.Local).AddTicks(5439) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 5, 20, 153, DateTimeKind.Local).AddTicks(5441), new DateTime(2024, 4, 5, 23, 5, 20, 153, DateTimeKind.Local).AddTicks(5442) });

            migrationBuilder.UpdateData(
                table: "APP_CLAIM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 5, 20, 153, DateTimeKind.Local).AddTicks(5443), new DateTime(2024, 4, 5, 23, 5, 20, 153, DateTimeKind.Local).AddTicks(5443) });

            migrationBuilder.UpdateData(
                table: "APP_USER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 5, 20, 155, DateTimeKind.Local).AddTicks(8159), new DateTime(2024, 4, 5, 23, 5, 20, 155, DateTimeKind.Local).AddTicks(8161) });

            migrationBuilder.UpdateData(
                table: "APP_USER_CLAIM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 5, 20, 154, DateTimeKind.Local).AddTicks(4260), new DateTime(2024, 4, 5, 23, 5, 20, 154, DateTimeKind.Local).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "PARAMETER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 5, 20, 165, DateTimeKind.Local).AddTicks(1688), new DateTime(2024, 4, 5, 23, 5, 20, 165, DateTimeKind.Local).AddTicks(1691) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 5, 20, 164, DateTimeKind.Local).AddTicks(9300), new DateTime(2024, 4, 5, 23, 5, 20, 164, DateTimeKind.Local).AddTicks(9309) });

            migrationBuilder.UpdateData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CR_DATE", "MOD_DATE" },
                values: new object[] { new DateTime(2024, 4, 5, 23, 5, 20, 164, DateTimeKind.Local).AddTicks(9313), new DateTime(2024, 4, 5, 23, 5, 20, 164, DateTimeKind.Local).AddTicks(9313) });
        }
    }
}
