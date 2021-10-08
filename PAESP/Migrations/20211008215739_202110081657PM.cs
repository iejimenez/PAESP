using Microsoft.EntityFrameworkCore.Migrations;

namespace PAESP.Migrations
{
    public partial class _202110081657PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materia_IdMateria",
                table: "Grupos");

            migrationBuilder.AddColumn<int>(
                name: "MateriaIdMateria",
                table: "Grupos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_MateriaIdMateria",
                table: "Grupos",
                column: "MateriaIdMateria");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materia_IdMateria",
                table: "Grupos",
                column: "IdMateria",
                principalTable: "Materia",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materia_MateriaIdMateria",
                table: "Grupos",
                column: "MateriaIdMateria",
                principalTable: "Materia",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materia_IdMateria",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materia_MateriaIdMateria",
                table: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_MateriaIdMateria",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "MateriaIdMateria",
                table: "Grupos");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materia_IdMateria",
                table: "Grupos",
                column: "IdMateria",
                principalTable: "Materia",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
