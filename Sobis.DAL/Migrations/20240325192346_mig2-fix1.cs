using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sobis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig2fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PRODUCT_TYPE_ID",
                table: "PRODUCT",
                type: "integer",
                unicode: false,
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "PARAMETER",
                columns: new[] { "ID", "CR_DATE", "CR_USER", "MOD_DATE", "MOD_USER", "PARAM_NAME", "STATUS" },
                values: new object[] { 1, new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(9814), null, new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(9817), null, "Product Type Id", "E" });

            migrationBuilder.InsertData(
                table: "PARAMETER_DETAIL",
                columns: new[] { "ID", "CR_DATE", "CR_USER", "DATA", "DATA_VALUE", "MOD_DATE", "MOD_USER", "ORDER_NO", "PARAM_DETAIL_NAME", "PARAM_ID", "PARENT_DATA_ID", "STATUS" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(7122), null, 1, null, new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(7130), null, null, "New Brand", 1, 0, "E" },
                    { 2, new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(7133), null, 2, null, new DateTime(2024, 3, 25, 22, 23, 46, 609, DateTimeKind.Local).AddTicks(7133), null, null, "Pre Owned", 1, 0, "E" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PARAMETER_DETAIL",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PARAMETER",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "PRODUCT_TYPE_ID",
                table: "PRODUCT");

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
        }
    }
}
