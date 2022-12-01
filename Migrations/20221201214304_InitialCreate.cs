using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFrontBack.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpcionEstado = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoInspeccions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInspeccions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspeccions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(nullable: false),
                    Comentarios = table.Column<string>(maxLength: 200, nullable: true),
                    TipoInspeccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspeccions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspeccions_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspeccions_TipoInspeccions_TipoInspeccionId",
                        column: x => x.TipoInspeccionId,
                        principalTable: "TipoInspeccions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccions_EstadoId",
                table: "Inspeccions",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspeccions_TipoInspeccionId",
                table: "Inspeccions",
                column: "TipoInspeccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspeccions");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "TipoInspeccions");
        }
    }
}
