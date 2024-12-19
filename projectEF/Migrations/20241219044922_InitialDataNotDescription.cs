using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataNotDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc412"),
                column: "FechaCreacion",
                value: new DateTime(2024, 12, 18, 23, 49, 22, 185, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc413"),
                column: "FechaCreacion",
                value: new DateTime(2024, 12, 18, 23, 49, 22, 184, DateTimeKind.Local).AddTicks(9513));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc412"),
                column: "FechaCreacion",
                value: new DateTime(2024, 12, 18, 23, 47, 2, 857, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc413"),
                column: "FechaCreacion",
                value: new DateTime(2024, 12, 18, 23, 47, 2, 856, DateTimeKind.Local).AddTicks(1135));
        }
    }
}
