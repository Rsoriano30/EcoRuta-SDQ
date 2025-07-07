using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Structure.Migrations
{
    /// <inheritdoc />
    public partial class AddComentarioColumnToReportesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Reportes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Reportes");
        }
    }
}
