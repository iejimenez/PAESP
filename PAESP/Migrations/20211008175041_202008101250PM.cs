using Microsoft.EntityFrameworkCore.Migrations;

namespace PAESP.Migrations
{
    public partial class _202008101250PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programa_Estudiantes_EstudianteIdEstudiante",
                table: "Programa");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibos_Conceptos_ConceptoIdConcepto",
                table: "Recibos");

            migrationBuilder.DropIndex(
                name: "IX_Recibos_ConceptoIdConcepto",
                table: "Recibos");

            migrationBuilder.DropIndex(
                name: "IX_Programa_EstudianteIdEstudiante",
                table: "Programa");

            migrationBuilder.DropColumn(
                name: "ConceptoIdConcepto",
                table: "Recibos");

            migrationBuilder.DropColumn(
                name: "EstudianteIdEstudiante",
                table: "Programa");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_IdConcepto",
                table: "Recibos",
                column: "IdConcepto");

            migrationBuilder.AddForeignKey(
                name: "FK_Recibos_Conceptos_IdConcepto",
                table: "Recibos",
                column: "IdConcepto",
                principalTable: "Conceptos",
                principalColumn: "IdConcepto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recibos_Conceptos_IdConcepto",
                table: "Recibos");

            migrationBuilder.DropIndex(
                name: "IX_Recibos_IdConcepto",
                table: "Recibos");

            migrationBuilder.AddColumn<int>(
                name: "ConceptoIdConcepto",
                table: "Recibos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstudianteIdEstudiante",
                table: "Programa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ConceptoIdConcepto",
                table: "Recibos",
                column: "ConceptoIdConcepto");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_EstudianteIdEstudiante",
                table: "Programa",
                column: "EstudianteIdEstudiante");

            migrationBuilder.AddForeignKey(
                name: "FK_Programa_Estudiantes_EstudianteIdEstudiante",
                table: "Programa",
                column: "EstudianteIdEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "IdEstudiante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recibos_Conceptos_ConceptoIdConcepto",
                table: "Recibos",
                column: "ConceptoIdConcepto",
                principalTable: "Conceptos",
                principalColumn: "IdConcepto",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
