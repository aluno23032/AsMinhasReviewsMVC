using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteReviews.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "DataNascimento", "Email", "Fotografia", "NomeUtilizador", "UserID" },
                values: new object[] { 1, new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "josesilva5@gmail.com", "Jose.jpg", "josesilva", null });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "DataNascimento", "Email", "Fotografia", "NomeUtilizador", "UserID" },
                values: new object[] { 2, new DateTime(2004, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariasantos1@gmail.com", "Maria.jpg", "mariasantos", null });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "DataNascimento", "Email", "Fotografia", "NomeUtilizador", "UserID" },
                values: new object[] { 3, new DateTime(2007, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "ricardosousa8@gmail.com", "Ricardo.jpg", "ricardosousa", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
