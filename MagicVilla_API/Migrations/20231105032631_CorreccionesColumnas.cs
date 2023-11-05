using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionesColumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ocuppants",
                table: "Villas",
                newName: "Occupants");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CrationDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 26, 31, 742, DateTimeKind.Local).AddTicks(5940), new DateTime(2023, 11, 5, 0, 26, 31, 742, DateTimeKind.Local).AddTicks(5948) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CrationDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 26, 31, 742, DateTimeKind.Local).AddTicks(5950), new DateTime(2023, 11, 5, 0, 26, 31, 742, DateTimeKind.Local).AddTicks(5951) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Occupants",
                table: "Villas",
                newName: "Ocuppants");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CrationDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4600), new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4609) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CrationDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4611), new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4611) });
        }
    }
}
