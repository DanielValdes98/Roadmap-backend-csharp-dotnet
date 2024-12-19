using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc402"), "Descripción de la categoría act personales", "Actividades personales", 20 },
                    { new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc477"), "Descripción de la categoría act pendientes", "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc412"), new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc402"), "Descripción de la compra", new DateTime(2024, 12, 18, 23, 47, 2, 857, DateTimeKind.Local).AddTicks(2093), 1, "Comprar regalo de cumpleaños" },
                    { new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc413"), new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc477"), "Descripción del pago", new DateTime(2024, 12, 18, 23, 47, 2, 856, DateTimeKind.Local).AddTicks(1135), 2, "Revisar pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc412"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc413"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc402"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc477"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
