using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAESP.Migrations
{
    public partial class _202110081746PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materia_IdMateria",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materia_MateriaIdMateria",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaMateria_Materia_IdMateria",
                table: "ProgramaMateria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materia",
                table: "Materia");

            migrationBuilder.RenameTable(
                name: "Materia",
                newName: "Materias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materias",
                table: "Materias",
                column: "IdMateria");

            migrationBuilder.CreateTable(
                name: "Periodos",
                columns: table => new
                {
                    IdPeriodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.IdPeriodo);
                });

            migrationBuilder.CreateTable(
                name: "CalendarioAcademicos",
                columns: table => new
                {
                    IdCalendarioAcademico = table.Column<int>(type: "int", nullable: false),
                    IdPeriodo = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Semestre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    academicYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarioAcademicos", x => x.IdCalendarioAcademico);
                    table.ForeignKey(
                        name: "FK_CalendarioAcademicos_Periodos_IdCalendarioAcademico",
                        column: x => x.IdCalendarioAcademico,
                        principalTable: "Periodos",
                        principalColumn: "IdPeriodo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materias_IdMateria",
                table: "Grupos",
                column: "IdMateria",
                principalTable: "Materias",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materias_MateriaIdMateria",
                table: "Grupos",
                column: "MateriaIdMateria",
                principalTable: "Materias",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaMateria_Materias_IdMateria",
                table: "ProgramaMateria",
                column: "IdMateria",
                principalTable: "Materias",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materias_IdMateria",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materias_MateriaIdMateria",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaMateria_Materias_IdMateria",
                table: "ProgramaMateria");

            migrationBuilder.DropTable(
                name: "CalendarioAcademicos");

            migrationBuilder.DropTable(
                name: "Periodos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materias",
                table: "Materias");

            migrationBuilder.RenameTable(
                name: "Materias",
                newName: "Materia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materia",
                table: "Materia",
                column: "IdMateria");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaMateria_Materia_IdMateria",
                table: "ProgramaMateria",
                column: "IdMateria",
                principalTable: "Materia",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
