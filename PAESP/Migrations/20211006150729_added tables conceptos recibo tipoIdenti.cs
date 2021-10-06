using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAESP.Migrations
{
    public partial class addedtablesconceptosrecibotipoIdenti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conceptos",
                columns: table => new
                {
                    IdConcepto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoConcepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ConceptoIdConcepto",
                table: "Recibos",
                column: "ConceptoIdConcepto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "TipoIdentificacions");

            migrationBuilder.DropTable(
                name: "Conceptos");
        }
    }
}
