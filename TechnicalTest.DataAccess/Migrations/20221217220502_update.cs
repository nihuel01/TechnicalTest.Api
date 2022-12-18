using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.DataAccess.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tGeneroPelicula_tGenero_tGenerocod_genero",
                table: "tGeneroPelicula");

            migrationBuilder.DropForeignKey(
                name: "FK_tGeneroPelicula_tPelicula_tPeliculacod_pelicula",
                table: "tGeneroPelicula");

            migrationBuilder.DropForeignKey(
                name: "FK_tUserPeliculaRent_tPelicula_tPeliculacod_pelicula",
                table: "tUserPeliculaRent");

            migrationBuilder.DropForeignKey(
                name: "FK_tUserPeliculaRent_tUsers_tUserId",
                table: "tUserPeliculaRent");

            migrationBuilder.DropForeignKey(
                name: "FK_tUserPeliculaSell_tPelicula_tPeliculacod_pelicula",
                table: "tUserPeliculaSell");

            migrationBuilder.DropForeignKey(
                name: "FK_tUserPeliculaSell_tUsers_tUserId",
                table: "tUserPeliculaSell");

            migrationBuilder.DropForeignKey(
                name: "FK_tUsers_tRol_tRolcod_rol",
                table: "tUsers");

            migrationBuilder.DropIndex(
                name: "IX_tUsers_tRolcod_rol",
                table: "tUsers");

            migrationBuilder.DropIndex(
                name: "IX_tUserPeliculaSell_tPeliculacod_pelicula",
                table: "tUserPeliculaSell");

            migrationBuilder.DropIndex(
                name: "IX_tUserPeliculaSell_tUserId",
                table: "tUserPeliculaSell");

            migrationBuilder.DropIndex(
                name: "IX_tUserPeliculaRent_tPeliculacod_pelicula",
                table: "tUserPeliculaRent");

            migrationBuilder.DropIndex(
                name: "IX_tUserPeliculaRent_tUserId",
                table: "tUserPeliculaRent");

            migrationBuilder.DropIndex(
                name: "IX_tGeneroPelicula_tGenerocod_genero",
                table: "tGeneroPelicula");

            migrationBuilder.DropIndex(
                name: "IX_tGeneroPelicula_tPeliculacod_pelicula",
                table: "tGeneroPelicula");

            migrationBuilder.DropColumn(
                name: "tRolcod_rol",
                table: "tUsers");

            migrationBuilder.DropColumn(
                name: "tPeliculacod_pelicula",
                table: "tUserPeliculaSell");

            migrationBuilder.DropColumn(
                name: "tUserId",
                table: "tUserPeliculaSell");

            migrationBuilder.DropColumn(
                name: "tPeliculacod_pelicula",
                table: "tUserPeliculaRent");

            migrationBuilder.DropColumn(
                name: "tUserId",
                table: "tUserPeliculaRent");

            migrationBuilder.DropColumn(
                name: "tGenerocod_genero",
                table: "tGeneroPelicula");

            migrationBuilder.DropColumn(
                name: "tPeliculacod_pelicula",
                table: "tGeneroPelicula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tRolcod_rol",
                table: "tUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tPeliculacod_pelicula",
                table: "tUserPeliculaSell",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "tUserId",
                table: "tUserPeliculaSell",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tPeliculacod_pelicula",
                table: "tUserPeliculaRent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "tUserId",
                table: "tUserPeliculaRent",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tGenerocod_genero",
                table: "tGeneroPelicula",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tPeliculacod_pelicula",
                table: "tGeneroPelicula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tUsers_tRolcod_rol",
                table: "tUsers",
                column: "tRolcod_rol");

            migrationBuilder.CreateIndex(
                name: "IX_tUserPeliculaSell_tPeliculacod_pelicula",
                table: "tUserPeliculaSell",
                column: "tPeliculacod_pelicula");

            migrationBuilder.CreateIndex(
                name: "IX_tUserPeliculaSell_tUserId",
                table: "tUserPeliculaSell",
                column: "tUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tUserPeliculaRent_tPeliculacod_pelicula",
                table: "tUserPeliculaRent",
                column: "tPeliculacod_pelicula");

            migrationBuilder.CreateIndex(
                name: "IX_tUserPeliculaRent_tUserId",
                table: "tUserPeliculaRent",
                column: "tUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tGeneroPelicula_tGenerocod_genero",
                table: "tGeneroPelicula",
                column: "tGenerocod_genero");

            migrationBuilder.CreateIndex(
                name: "IX_tGeneroPelicula_tPeliculacod_pelicula",
                table: "tGeneroPelicula",
                column: "tPeliculacod_pelicula");

            migrationBuilder.AddForeignKey(
                name: "FK_tGeneroPelicula_tGenero_tGenerocod_genero",
                table: "tGeneroPelicula",
                column: "tGenerocod_genero",
                principalTable: "tGenero",
                principalColumn: "cod_genero",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tGeneroPelicula_tPelicula_tPeliculacod_pelicula",
                table: "tGeneroPelicula",
                column: "tPeliculacod_pelicula",
                principalTable: "tPelicula",
                principalColumn: "cod_pelicula",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tUserPeliculaRent_tPelicula_tPeliculacod_pelicula",
                table: "tUserPeliculaRent",
                column: "tPeliculacod_pelicula",
                principalTable: "tPelicula",
                principalColumn: "cod_pelicula",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tUserPeliculaRent_tUsers_tUserId",
                table: "tUserPeliculaRent",
                column: "tUserId",
                principalTable: "tUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tUserPeliculaSell_tPelicula_tPeliculacod_pelicula",
                table: "tUserPeliculaSell",
                column: "tPeliculacod_pelicula",
                principalTable: "tPelicula",
                principalColumn: "cod_pelicula",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tUserPeliculaSell_tUsers_tUserId",
                table: "tUserPeliculaSell",
                column: "tUserId",
                principalTable: "tUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tUsers_tRol_tRolcod_rol",
                table: "tUsers",
                column: "tRolcod_rol",
                principalTable: "tRol",
                principalColumn: "cod_rol",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
