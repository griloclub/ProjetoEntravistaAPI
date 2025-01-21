using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoTesteDev.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSenhahash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2b$10$9u3sj4iXBo67dnpTXrnfjess1we2nID95Ofambb9J0ZBqmAZM.3vC");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2b$10$3RshRzxXA/M.TzXAM7UGO.sHCMCXyUIO7eeBzvogRkdmmJ.05oD.6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$12$eImiTXuWVxfM37uY4JANjQeQO/q8.W.uSnY04mQAR2XN0AQzj5mE2");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$12$g5Y8jPzblDFc1RYbGnD5heWfnZVJcWtcF4Thqlfcb7wDYJjLHFg3y");
        }
    }
}
