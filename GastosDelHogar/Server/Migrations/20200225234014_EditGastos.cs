using Microsoft.EntityFrameworkCore.Migrations;

namespace GastosDelHogar.Server.Migrations
{
    public partial class EditGastos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cuotas",
                table: "Gastos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cuotas",
                table: "Gastos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
