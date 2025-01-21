using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoTesteDev.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "Aberta", "HorarioAbertura", "HorarioFechamento", "Numero" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 1, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), null, "M001" },
                    { 2, false, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "M002" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "SenhaHash" },
                values: new object[,]
                {
                    { 1, "admin@teste.com", "Admin", "$2a$12$eImiTXuWVxfM37uY4JANjQeQO/q8.W.uSnY04mQAR2XN0AQzj5mE2" },
                    { 2, "tiago@teste.com", "Tiago", "$2a$12$g5Y8jPzblDFc1RYbGnD5heWfnZVJcWtcF4Thqlfcb7wDYJjLHFg3y" }
                });

            migrationBuilder.InsertData(
                table: "ItensConsumidos",
                columns: new[] { "Id", "MesaId", "Nome", "Valor" },
                values: new object[,]
                {
                    { 1, 1, "Cerveja", 10.5m },
                    { 2, 1, "Petisco", 25.0m },
                    { 3, 2, "Refrigerante", 7.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItensConsumidos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItensConsumidos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItensConsumidos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
