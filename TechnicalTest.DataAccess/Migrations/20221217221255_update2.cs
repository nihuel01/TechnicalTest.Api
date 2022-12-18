using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.DataAccess.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "tUserPeliculaSell");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tUserPeliculaRent");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tRol");

            migrationBuilder.DropColumn(
                name: "sn_activo",
                table: "tRol");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tPelicula");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tGeneroPelicula");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tGenero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "tUserPeliculaSell",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "tUserPeliculaRent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "tRol",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "sn_activo",
                table: "tRol",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "tPelicula",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "tGeneroPelicula",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "tGenero",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
