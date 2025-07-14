using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Structure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camiones",
                columns: table => new
                {
                    CamionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Año = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Camiones__80E86F48C593860A", x => x.CamionID);
                });

            migrationBuilder.CreateTable(
                name: "Choferes",
                columns: table => new
                {
                    ChoferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Choferes__3969BEED721C13A9", x => x.ChoferID);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    HorarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraSalida = table.Column<TimeOnly>(type: "time", nullable: true),
                    HoraLlegada = table.Column<TimeOnly>(type: "time", nullable: true),
                    DiaInicio = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DiaFin = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Horarios__BB881A9E8F21866F", x => x.HorarioID);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    RutaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRuta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PuntoInicio = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PuntoFinal = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rutas__7B6199EED35AD4C1", x => x.RutaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TipoUsuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__2B3DE7980953A9C9", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionesRuta",
                columns: table => new
                {
                    AsignacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaID = table.Column<int>(type: "int", nullable: true),
                    HorarioID = table.Column<int>(type: "int", nullable: true),
                    ChoferID = table.Column<int>(type: "int", nullable: true),
                    CamionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Asignaci__D82B5BB73183954C", x => x.AsignacionID);
                    table.ForeignKey(
                        name: "FK__Asignacio__Camio__72C60C4A",
                        column: x => x.CamionID,
                        principalTable: "Camiones",
                        principalColumn: "CamionID");
                    table.ForeignKey(
                        name: "FK__Asignacio__Chofe__71D1E811",
                        column: x => x.ChoferID,
                        principalTable: "Choferes",
                        principalColumn: "ChoferID");
                    table.ForeignKey(
                        name: "FK__Asignacio__Horar__70DDC3D8",
                        column: x => x.HorarioID,
                        principalTable: "Horarios",
                        principalColumn: "HorarioID");
                    table.ForeignKey(
                        name: "FK__Asignacio__RutaI__6FE99F9F",
                        column: x => x.RutaID,
                        principalTable: "Rutas",
                        principalColumn: "RutaID");
                });

            migrationBuilder.CreateTable(
                name: "LogsActividad",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LogsActi__5E5499A8A018F034", x => x.LogID);
                    table.ForeignKey(
                        name: "FK__LogsActiv__Usuar__76969D2E",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    ReporteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Pendiente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reportes__0B29EA4E176EA4EB", x => x.ReporteID);
                    table.ForeignKey(
                        name: "FK__Reportes__Usuari__5070F446",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesRuta_CamionID",
                table: "AsignacionesRuta",
                column: "CamionID");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesRuta_ChoferID",
                table: "AsignacionesRuta",
                column: "ChoferID");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesRuta_HorarioID",
                table: "AsignacionesRuta",
                column: "HorarioID");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesRuta_RutaID",
                table: "AsignacionesRuta",
                column: "RutaID");

            migrationBuilder.CreateIndex(
                name: "UQ__Camiones__8310F99D32D16B5F",
                table: "Camiones",
                column: "Placa",
                unique: true,
                filter: "[Placa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Choferes__B4ADFE385935BA72",
                table: "Choferes",
                column: "Cedula",
                unique: true,
                filter: "[Cedula] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LogsActividad_UsuarioID",
                table: "LogsActividad",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_UsuarioID",
                table: "Reportes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__60695A190B8CFD6E",
                table: "Usuarios",
                column: "Correo",
                unique: true,
                filter: "[Correo] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionesRuta");

            migrationBuilder.DropTable(
                name: "LogsActividad");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Camiones");

            migrationBuilder.DropTable(
                name: "Choferes");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
