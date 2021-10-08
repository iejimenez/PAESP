using Microsoft.EntityFrameworkCore.Migrations;

namespace PAESP.Migrations
{
    public partial class _202110081625PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupo_Materia_IdMateria",
                table: "Grupo");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupo_Profesor_IdProfesor",
                table: "Grupo");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoAula_Aula_IdAula",
                table: "GrupoAula");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoAula_Grupo_IdGrupo",
                table: "GrupoAula");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoEstudiante_Estudiantes_EstudianteIdEstudiante",
                table: "GrupoEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoEstudiante_Estudiantes_IdEstudiante",
                table: "GrupoEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoEstudiante_Grupo_GrupoIdGrupo",
                table: "GrupoEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoEstudiante_Grupo_IdGrupo",
                table: "GrupoEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_Usuarios_IdUsuario",
                table: "Profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoEstudiante",
                table: "GrupoEstudiante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoAula",
                table: "GrupoAula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grupo",
                table: "Grupo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aula",
                table: "Aula");

            migrationBuilder.RenameTable(
                name: "Profesor",
                newName: "Profesores");

            migrationBuilder.RenameTable(
                name: "GrupoEstudiante",
                newName: "GrupoEstudiantes");

            migrationBuilder.RenameTable(
                name: "GrupoAula",
                newName: "GrupoAulas");

            migrationBuilder.RenameTable(
                name: "Grupo",
                newName: "Grupos");

            migrationBuilder.RenameTable(
                name: "Aula",
                newName: "Aulas");

            migrationBuilder.RenameIndex(
                name: "IX_Profesor_IdUsuario",
                table: "Profesores",
                newName: "IX_Profesores_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoEstudiante_IdGrupo",
                table: "GrupoEstudiantes",
                newName: "IX_GrupoEstudiantes_IdGrupo");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoEstudiante_IdEstudiante",
                table: "GrupoEstudiantes",
                newName: "IX_GrupoEstudiantes_IdEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoEstudiante_GrupoIdGrupo",
                table: "GrupoEstudiantes",
                newName: "IX_GrupoEstudiantes_GrupoIdGrupo");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoEstudiante_EstudianteIdEstudiante",
                table: "GrupoEstudiantes",
                newName: "IX_GrupoEstudiantes_EstudianteIdEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoAula_IdGrupo",
                table: "GrupoAulas",
                newName: "IX_GrupoAulas_IdGrupo");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoAula_IdAula",
                table: "GrupoAulas",
                newName: "IX_GrupoAulas_IdAula");

            migrationBuilder.RenameIndex(
                name: "IX_Grupo_IdProfesor",
                table: "Grupos",
                newName: "IX_Grupos_IdProfesor");

            migrationBuilder.RenameIndex(
                name: "IX_Grupo_IdMateria",
                table: "Grupos",
                newName: "IX_Grupos_IdMateria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores",
                column: "IdProfesor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoEstudiantes",
                table: "GrupoEstudiantes",
                column: "IdGrupoEstudiante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoAulas",
                table: "GrupoAulas",
                column: "IdGrupoaula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grupos",
                table: "Grupos",
                column: "IdGrupo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas",
                column: "IdAula");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoAulas_Aulas_IdAula",
                table: "GrupoAulas",
                column: "IdAula",
                principalTable: "Aulas",
                principalColumn: "IdAula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoAulas_Grupos_IdGrupo",
                table: "GrupoAulas",
                column: "IdGrupo",
                principalTable: "Grupos",
                principalColumn: "IdGrupo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoEstudiantes_Estudiantes_EstudianteIdEstudiante",
                table: "GrupoEstudiantes",
                column: "EstudianteIdEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "IdEstudiante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoEstudiantes_Estudiantes_IdEstudiante",
                table: "GrupoEstudiantes",
                column: "IdEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "IdEstudiante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoEstudiantes_Grupos_GrupoIdGrupo",
                table: "GrupoEstudiantes",
                column: "GrupoIdGrupo",
                principalTable: "Grupos",
                principalColumn: "IdGrupo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoEstudiantes_Grupos_IdGrupo",
                table: "GrupoEstudiantes",
                column: "IdGrupo",
                principalTable: "Grupos",
                principalColumn: "IdGrupo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materia_IdMateria",
                table: "Grupos",
                column: "IdMateria",
                principalTable: "Materia",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Profesores_IdProfesor",
                table: "Grupos",
                column: "IdProfesor",
                principalTable: "Profesores",
                principalColumn: "IdProfesor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Usuarios_IdUsuario",
                table: "Profesores",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoAulas_Aulas_IdAula",
                table: "GrupoAulas");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoAulas_Grupos_IdGrupo",
                table: "GrupoAulas");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoEstudiantes_Estudiantes_EstudianteIdEstudiante",
                table: "GrupoEstudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoEstudiantes_Estudiantes_IdEstudiante",
                table: "GrupoEstudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoEstudiantes_Grupos_GrupoIdGrupo",
                table: "GrupoEstudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoEstudiantes_Grupos_IdGrupo",
                table: "GrupoEstudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materia_IdMateria",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Profesores_IdProfesor",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Usuarios_IdUsuario",
                table: "Profesores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grupos",
                table: "Grupos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoEstudiantes",
                table: "GrupoEstudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoAulas",
                table: "GrupoAulas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas");

            migrationBuilder.RenameTable(
                name: "Profesores",
                newName: "Profesor");

            migrationBuilder.RenameTable(
                name: "Grupos",
                newName: "Grupo");

            migrationBuilder.RenameTable(
                name: "GrupoEstudiantes",
                newName: "GrupoEstudiante");

            migrationBuilder.RenameTable(
                name: "GrupoAulas",
                newName: "GrupoAula");

            migrationBuilder.RenameTable(
                name: "Aulas",
                newName: "Aula");

            migrationBuilder.RenameIndex(
                name: "IX_Profesores_IdUsuario",
                table: "Profesor",
                newName: "IX_Profesor_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Grupos_IdProfesor",
                table: "Grupo",
                newName: "IX_Grupo_IdProfesor");

            migrationBuilder.RenameIndex(
                name: "IX_Grupos_IdMateria",
                table: "Grupo",
                newName: "IX_Grupo_IdMateria");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoEstudiantes_IdGrupo",
                table: "GrupoEstudiante",
                newName: "IX_GrupoEstudiante_IdGrupo");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoEstudiantes_IdEstudiante",
                table: "GrupoEstudiante",
                newName: "IX_GrupoEstudiante_IdEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoEstudiantes_GrupoIdGrupo",
                table: "GrupoEstudiante",
                newName: "IX_GrupoEstudiante_GrupoIdGrupo");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoEstudiantes_EstudianteIdEstudiante",
                table: "GrupoEstudiante",
                newName: "IX_GrupoEstudiante_EstudianteIdEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoAulas_IdGrupo",
                table: "GrupoAula",
                newName: "IX_GrupoAula_IdGrupo");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoAulas_IdAula",
                table: "GrupoAula",
                newName: "IX_GrupoAula_IdAula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor",
                column: "IdProfesor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grupo",
                table: "Grupo",
                column: "IdGrupo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoEstudiante",
                table: "GrupoEstudiante",
                column: "IdGrupoEstudiante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoAula",
                table: "GrupoAula",
                column: "IdGrupoaula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aula",
                table: "Aula",
                column: "IdAula");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupo_Materia_IdMateria",
                table: "Grupo",
                column: "IdMateria",
                principalTable: "Materia",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupo_Profesor_IdProfesor",
                table: "Grupo",
                column: "IdProfesor",
                principalTable: "Profesor",
                principalColumn: "IdProfesor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoAula_Aula_IdAula",
                table: "GrupoAula",
                column: "IdAula",
                principalTable: "Aula",
                principalColumn: "IdAula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoAula_Grupo_IdGrupo",
                table: "GrupoAula",
                column: "IdGrupo",
                principalTable: "Grupo",
                principalColumn: "IdGrupo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoEstudiante_Estudiantes_EstudianteIdEstudiante",
                table: "GrupoEstudiante",
                column: "EstudianteIdEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "IdEstudiante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoEstudiante_Estudiantes_IdEstudiante",
                table: "GrupoEstudiante",
                column: "IdEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "IdEstudiante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoEstudiante_Grupo_GrupoIdGrupo",
                table: "GrupoEstudiante",
                column: "GrupoIdGrupo",
                principalTable: "Grupo",
                principalColumn: "IdGrupo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoEstudiante_Grupo_IdGrupo",
                table: "GrupoEstudiante",
                column: "IdGrupo",
                principalTable: "Grupo",
                principalColumn: "IdGrupo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_Usuarios_IdUsuario",
                table: "Profesor",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
