using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Structure.Migrations
{
    /// <inheritdoc />
    public partial class AddeOnDeleteBehaviorInAsignaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Asignacio__Camio__72C60C4A",
                table: "AsignacionesRuta");

            migrationBuilder.DropForeignKey(
                name: "FK__Asignacio__Chofe__71D1E811",
                table: "AsignacionesRuta");

            migrationBuilder.DropForeignKey(
                name: "FK__Asignacio__Horar__70DDC3D8",
                table: "AsignacionesRuta");

            migrationBuilder.DropForeignKey(
                name: "FK__Asignacio__RutaI__6FE99F9F",
                table: "AsignacionesRuta");

            migrationBuilder.AddForeignKey(
                name: "FK__Asignacio__Camio__72C60C4A",
                table: "AsignacionesRuta",
                column: "CamionID",
                principalTable: "Camiones",
                principalColumn: "CamionID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Asignacio__Chofe__71D1E811",
                table: "AsignacionesRuta",
                column: "ChoferID",
                principalTable: "Choferes",
                principalColumn: "ChoferID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Asignacio__Horar__70DDC3D8",
                table: "AsignacionesRuta",
                column: "HorarioID",
                principalTable: "Horarios",
                principalColumn: "HorarioID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Asignacio__RutaI__6FE99F9F",
                table: "AsignacionesRuta",
                column: "RutaID",
                principalTable: "Rutas",
                principalColumn: "RutaID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Asignacio__Camio__72C60C4A",
                table: "AsignacionesRuta");

            migrationBuilder.DropForeignKey(
                name: "FK__Asignacio__Chofe__71D1E811",
                table: "AsignacionesRuta");

            migrationBuilder.DropForeignKey(
                name: "FK__Asignacio__Horar__70DDC3D8",
                table: "AsignacionesRuta");

            migrationBuilder.DropForeignKey(
                name: "FK__Asignacio__RutaI__6FE99F9F",
                table: "AsignacionesRuta");

            migrationBuilder.AddForeignKey(
                name: "FK__Asignacio__Camio__72C60C4A",
                table: "AsignacionesRuta",
                column: "CamionID",
                principalTable: "Camiones",
                principalColumn: "CamionID");

            migrationBuilder.AddForeignKey(
                name: "FK__Asignacio__Chofe__71D1E811",
                table: "AsignacionesRuta",
                column: "ChoferID",
                principalTable: "Choferes",
                principalColumn: "ChoferID");

            migrationBuilder.AddForeignKey(
                name: "FK__Asignacio__Horar__70DDC3D8",
                table: "AsignacionesRuta",
                column: "HorarioID",
                principalTable: "Horarios",
                principalColumn: "HorarioID");

            migrationBuilder.AddForeignKey(
                name: "FK__Asignacio__RutaI__6FE99F9F",
                table: "AsignacionesRuta",
                column: "RutaID",
                principalTable: "Rutas",
                principalColumn: "RutaID");
        }
    }
}
