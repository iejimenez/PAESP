using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAESP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aula",
                columns: table => new
                {
                    IdAula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreAula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bloque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aula", x => x.IdAula);
                });

            migrationBuilder.CreateTable(
                name: "Conceptos",
                columns: table => new
                {
                    IdConcepto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoConcepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoConcepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.IdConcepto);
                });

            migrationBuilder.CreateTable(
                name: "configuraciones",
                columns: table => new
                {
                    IdConfig = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuraciones", x => x.IdConfig);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    IdMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creditos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.IdMateria);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificacions",
                columns: table => new
                {
                    IdTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacions", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipodeIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apeliidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    IdRecibo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroRecibo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdConcepto = table.Column<int>(type: "int", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaReg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConceptoIdConcepto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.IdRecibo);
                    table.ForeignKey(
                        name: "FK_Recibos_Conceptos_ConceptoIdConcepto",
                        column: x => x.ConceptoIdConcepto,
                        principalTable: "Conceptos",
                        principalColumn: "IdConcepto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FEchaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preinscripcions",
                columns: table => new
                {
                    IdPresinscripcion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaDePreInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroRecibo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    PersonaIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preinscripcions", x => x.IdPresinscripcion);
                    table.ForeignKey(
                        name: "FK_Preinscripcions_Usuarios_PersonaIdUsuario",
                        column: x => x.PersonaIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    IdProfesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.IdProfesor);
                    table.ForeignKey(
                        name: "FK_Profesor_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombrePograma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semestres = table.Column<int>(type: "int", nullable: false),
                    EstudianteIdEstudiante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Programa_Estudiantes_EstudianteIdEstudiante",
                        column: x => x.EstudianteIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    IdMateria = table.Column<int>(type: "int", nullable: false),
                    IdProfesor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.IdGrupo);
                    table.ForeignKey(
                        name: "FK_Grupo_Materia_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Materia",
                        principalColumn: "IdMateria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grupo_Profesor_IdProfesor",
                        column: x => x.IdProfesor,
                        principalTable: "Profesor",
                        principalColumn: "IdProfesor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaMateria",
                columns: table => new
                {
                    IdProgramaMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPrograma = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdMateria = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaMateria", x => x.IdProgramaMateria);
                    table.ForeignKey(
                        name: "FK_ProgramaMateria_Materia_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Materia",
                        principalColumn: "IdMateria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramaMateria_Programa_CodigoPrograma",
                        column: x => x.CodigoPrograma,
                        principalTable: "Programa",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupoAula",
                columns: table => new
                {
                    IdGrupoaula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAula = table.Column<int>(type: "int", nullable: false),
                    IdGrupo = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoAula", x => x.IdGrupoaula);
                    table.ForeignKey(
                        name: "FK_GrupoAula_Aula_IdAula",
                        column: x => x.IdAula,
                        principalTable: "Aula",
                        principalColumn: "IdAula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoAula_Grupo_IdGrupo",
                        column: x => x.IdGrupo,
                        principalTable: "Grupo",
                        principalColumn: "IdGrupo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoEstudiante",
                columns: table => new
                {
                    IdGrupoEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGrupo = table.Column<int>(type: "int", nullable: false),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    PrimerCorte = table.Column<double>(type: "float", nullable: false),
                    SegundoCorte = table.Column<double>(type: "float", nullable: false),
                    TercerCorte = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    EstudianteIdEstudiante = table.Column<int>(type: "int", nullable: false),
                    EstudianteIdEstudiante1 = table.Column<int>(type: "int", nullable: false),
                    GrupoIdGrupo = table.Column<int>(type: "int", nullable: false),
                    GrupoIdGrupo1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoEstudiante", x => x.IdGrupoEstudiante);
                    table.ForeignKey(
                        name: "FK_GrupoEstudiante_Estudiantes_EstudianteIdEstudiante",
                        column: x => x.EstudianteIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrupoEstudiante_Estudiantes_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrupoEstudiante_Grupo_GrupoIdGrupo",
                        column: x => x.GrupoIdGrupo,
                        principalTable: "Grupo",
                        principalColumn: "IdGrupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrupoEstudiante_Grupo_IdGrupo",
                        column: x => x.IdGrupo,
                        principalTable: "Grupo",
                        principalColumn: "IdGrupo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_IdUsuario",
                table: "Estudiantes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_IdMateria",
                table: "Grupo",
                column: "IdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_IdProfesor",
                table: "Grupo",
                column: "IdProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoAula_IdAula",
                table: "GrupoAula",
                column: "IdAula");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoAula_IdGrupo",
                table: "GrupoAula",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoEstudiante_EstudianteIdEstudiante",
                table: "GrupoEstudiante",
                column: "EstudianteIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoEstudiante_GrupoIdGrupo",
                table: "GrupoEstudiante",
                column: "GrupoIdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoEstudiante_IdEstudiante",
                table: "GrupoEstudiante",
                column: "IdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoEstudiante_IdGrupo",
                table: "GrupoEstudiante",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Preinscripcions_PersonaIdUsuario",
                table: "Preinscripcions",
                column: "PersonaIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_IdUsuario",
                table: "Profesor",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_EstudianteIdEstudiante",
                table: "Programa",
                column: "EstudianteIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaMateria_CodigoPrograma",
                table: "ProgramaMateria",
                column: "CodigoPrograma");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaMateria_IdMateria",
                table: "ProgramaMateria",
                column: "IdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ConceptoIdConcepto",
                table: "Recibos",
                column: "ConceptoIdConcepto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuraciones");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "GrupoAula");

            migrationBuilder.DropTable(
                name: "GrupoEstudiante");

            migrationBuilder.DropTable(
                name: "Preinscripcions");

            migrationBuilder.DropTable(
                name: "ProgramaMateria");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "TipoIdentificacions");

            migrationBuilder.DropTable(
                name: "Aula");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.DropTable(
                name: "Conceptos");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
