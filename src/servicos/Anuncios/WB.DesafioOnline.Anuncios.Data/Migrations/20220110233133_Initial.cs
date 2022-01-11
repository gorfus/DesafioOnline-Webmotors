using Microsoft.EntityFrameworkCore.Migrations;

namespace WB.DesafioOnline.Anuncios.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_AnuncioWebmotors",
                columns: table => new
                {
                    AnuncioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(45)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(45)", nullable: false),
                    Versao = table.Column<string>(type: "varchar(45)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AnuncioWebmotors", x => x.AnuncioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_AnuncioWebmotors");
        }
    }
}
