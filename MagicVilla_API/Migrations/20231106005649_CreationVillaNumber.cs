using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class CreationVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillasNumber",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillasNumber", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_VillasNumber_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CrationDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 11, 5, 21, 56, 49, 643, DateTimeKind.Local).AddTicks(1331), new DateTime(2023, 11, 5, 21, 56, 49, 643, DateTimeKind.Local).AddTicks(1338) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CrationDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 11, 5, 21, 56, 49, 643, DateTimeKind.Local).AddTicks(1340), new DateTime(2023, 11, 5, 21, 56, 49, 643, DateTimeKind.Local).AddTicks(1341) });

            migrationBuilder.CreateIndex(
                name: "IX_VillasNumber_VillaId",
                table: "VillasNumber",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillasNumber");

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
    }
}
