using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BovedaUru.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Personaje = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Grupo = table.Column<string>(type: "TEXT", nullable: false),
                    Año = table.Column<int>(type: "INTEGER", nullable: false),
                    Editorial = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Imagen = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ComicId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enlaces_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "Año", "Descripcion", "Editorial", "Grupo", "Imagen", "Personaje", "Titulo" },
                values: new object[,]
                {
                    { 1, 2014, "", "Marvel Comics", "Ghost Rider", "images/ANGR_01.jpg", "Ghost Rider", "All-New Ghost Rider" },
                    { 2, 2021, "", "Marvel Comics", "Asgard, Cosmico", "images/BETA_RAY_BILL_2021.jpg", "Beta Ray Bill", "Beta Ray Bill" },
                    { 3, 2011, "", "Marvel Comics", "Asgard, Eventos", "images/FEAR_ITSELF_BOOK_ONE.jpg", "Varios", "Fear Itself: Book One" },
                    { 4, 2019, "", "Marvel Comics", "Eventos", "images/WAR_OF_THE_REALMS_2019.jpg", "Varios", "War of the Realms" },
                    { 5, 1990, "", "Marvel Comics", "Ghost Rider", "images/SPIRITS_OF_VENGANCE.jpg", "Ghost Rider", "Ghost Rider & Blaze: Spirits of Vengeance" },
                    { 6, 2001, "", "Dark Horse Comics, Otras Editoriales", "Hellboy", "images/HELLBOY_ISSUE_1.jpg", "Hellboy", "Hellboy: Seed of Destruction" },
                    { 7, 1990, "", "Image Comics, Otras Editoriales", "Spawn", "images/SPAWN_15.jpg", "Spawn", "Spawn: issue #15" },
                    { 8, 1990, "", "Image Comics, Otras Editoriales", "Angela, Spawn", "images/ANGELA_SPAWN.jpg", "Angela", "Spawn: Issue #9" }
                });

            migrationBuilder.InsertData(
                table: "Enlaces",
                columns: new[] { "Id", "ComicId", "Nombre", "Url" },
                values: new object[,]
                {
                    { 1, 1, "Leer en sitio A", "https://ejemplo.com/a" },
                    { 2, 1, "Leer en sitio B", "https://ejemplo.com/b" },
                    { 3, 2, "Leer en sitio A", "https://ejemplo.com/c" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enlaces_ComicId",
                table: "Enlaces",
                column: "ComicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enlaces");

            migrationBuilder.DropTable(
                name: "Comics");
        }
    }
}
