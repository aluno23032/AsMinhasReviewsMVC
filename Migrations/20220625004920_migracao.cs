using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteReviews.Migrations
{
    public partial class migracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Objetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plataforma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diretor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Atores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desenvolvedores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NTemporadas = table.Column<int>(type: "int", nullable: true),
                    NEpisodios = table.Column<int>(type: "int", nullable: true),
                    Series_Diretor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Series_Atores = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUtilizador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fotografias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorFK = table.Column<int>(type: "int", nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotografias_Utilizadores_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadorFK = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    IdObjetoFK = table.Column<int>(type: "int", nullable: false),
                    FilmesId = table.Column<int>(type: "int", nullable: true),
                    JogosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Objetos_FilmesId",
                        column: x => x.FilmesId,
                        principalTable: "Objetos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Objetos_IdObjetoFK",
                        column: x => x.IdObjetoFK,
                        principalTable: "Objetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Objetos_JogosId",
                        column: x => x.JogosId,
                        principalTable: "Objetos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Utilizadores_CriadorFK",
                        column: x => x.CriadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotografias_UtilizadorFK",
                table: "Fotografias",
                column: "UtilizadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CriadorFK",
                table: "Reviews",
                column: "CriadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FilmesId",
                table: "Reviews",
                column: "FilmesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IdObjetoFK",
                table: "Reviews",
                column: "IdObjetoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_JogosId",
                table: "Reviews",
                column: "JogosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotografias");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Objetos");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
