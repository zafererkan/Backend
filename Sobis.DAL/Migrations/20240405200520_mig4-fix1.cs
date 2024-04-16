using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sobis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig4fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCT_SUB_CATEGORY_SUBCATEGORY_ID",
                table: "PRODUCT");

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

            migrationBuilder.AddForeignKey(
                name: "PRODUCT_FK2",
                table: "PRODUCT",
                column: "SUBCATEGORY_ID",
                principalTable: "SUB_CATEGORY",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PRODUCT_FK2",
                table: "PRODUCT");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCT_SUB_CATEGORY_SUBCATEGORY_ID",
                table: "PRODUCT",
                column: "SUBCATEGORY_ID",
                principalTable: "SUB_CATEGORY",
                principalColumn: "ID");
        }
    }
}
