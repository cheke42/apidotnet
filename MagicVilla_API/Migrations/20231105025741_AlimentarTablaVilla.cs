using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CrationDate", "Detail", "Fee", "ImageUrl", "Name", "Ocuppants", "SquareMeter", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4600), "Detalle de la Villa...", 200.0, "", "Villa Real", 5, 50, new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4609) },
                    { 2, "", new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4611), "Detalle de la Villa...", 150.0, "", "Premium Vista a la Piscina", 4, 40, new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4611) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
