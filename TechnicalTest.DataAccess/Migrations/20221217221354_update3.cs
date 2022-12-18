using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.DataAccess.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sn_activo",
                table: "tRol",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sn_activo",
                table: "tRol");
        }
    }
}
