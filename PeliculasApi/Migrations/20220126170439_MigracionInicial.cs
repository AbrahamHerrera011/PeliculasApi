using Microsoft.EntityFrameworkCore.Migrations;

namespace PeliculasApi.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    IDpeliculas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Director = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Genero = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    puntacion = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Anio_de_publicacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Idpeliculas", x => x.IDpeliculas);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}
