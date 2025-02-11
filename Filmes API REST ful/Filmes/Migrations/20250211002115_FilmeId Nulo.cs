using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes.Migrations
{
    public partial class FilmeIdNulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "filmes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
