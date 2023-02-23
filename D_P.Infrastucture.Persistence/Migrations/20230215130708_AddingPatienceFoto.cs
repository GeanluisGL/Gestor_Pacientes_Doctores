using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D_P.Infrastucture.Persistence.Migrations
{
    public partial class AddingPatienceFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoFileUrl",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoFileUrl",
                table: "Pacientes");
        }
    }
}
