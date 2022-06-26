using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteReviews.Migrations
{
    public partial class a : Migration
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
                    Capa = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    NomeUtilizador = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin = table.Column<bool>(type: "bit", nullable: false)
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
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotografias_Objetos_ObjetosId",
                        column: x => x.ObjetosId,
                        principalTable: "Objetos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CriadorFK = table.Column<int>(type: "int", nullable: false),
                    ObjetoFK = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Reviews_Objetos_JogosId",
                        column: x => x.JogosId,
                        principalTable: "Objetos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Objetos_ObjetoFK",
                        column: x => x.ObjetoFK,
                        principalTable: "Objetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Utilizadores_CriadorFK",
                        column: x => x.CriadorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Objetos",
                columns: new[] { "Id", "Series_Atores", "Capa", "DataLancamento", "Descricao", "Series_Diretor", "Discriminator", "NEpisodios", "NTemporadas", "Nome", "Plataforma" },
                values: new object[] { 1, null, "breakingbad.jpg", new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine in order to secure his family's future.", null, "Series", 0, 0, "Breaking Bad", "Netflix" });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "DataNascimento", "Email", "Fotografia", "NomeUtilizador", "UserID", "admin" },
                values: new object[,]
                {
                    { 1, new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "josesilva5@gmail.com", "Jose.png", "josesilva", null, false },
                    { 2, new DateTime(2004, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariasantos1@gmail.com", "Maria.jpg", "mariasantos", null, false },
                    { 3, new DateTime(2007, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "ricardosousa8@gmail.com", "Ricardo.jpg", "ricardosousa", null, false }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Conteudo", "CriadorFK", "DataCriacao", "FilmesId", "JogosId", "ObjetoFK", "Rating" },
                values: new object[] { 1, "When you finish the show you'll never be the same..I guarantee you", 1, new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Fotografias_ObjetosId",
                table: "Fotografias",
                column: "ObjetosId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CriadorFK",
                table: "Reviews",
                column: "CriadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FilmesId",
                table: "Reviews",
                column: "FilmesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_JogosId",
                table: "Reviews",
                column: "JogosId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ObjetoFK",
                table: "Reviews",
                column: "ObjetoFK");
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
