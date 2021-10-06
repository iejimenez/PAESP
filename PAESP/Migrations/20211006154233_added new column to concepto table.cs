using Microsoft.EntityFrameworkCore.Migrations;

namespace PAESP.Migrations
{
    public partial class addednewcolumntoconceptotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoConcepto",
                table: "Conceptos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoConcepto",
                table: "Conceptos");
        }
    }
}
