using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.DataAccess.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tGenero",
                columns: table => new
                {
                    cod_genero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tGenero", x => x.cod_genero);
                });

            migrationBuilder.CreateTable(
                name: "tPelicula",
                columns: table => new
                {
                    cod_pelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cant_disponibles_alquiler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cant_disponibles_venta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio_alquiler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio_venta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPelicula", x => x.cod_pelicula);
                });

            migrationBuilder.CreateTable(
                name: "tRol",
                columns: table => new
                {
                    cod_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sn_activo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tRol", x => x.cod_rol);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tGeneroPelicula",
                columns: table => new
                {
                    cod_pelicula = table.Column<int>(type: "int", nullable: false),
                    cod_genero = table.Column<int>(type: "int", nullable: false),
                    tPeliculacod_pelicula = table.Column<int>(type: "int", nullable: true),
                    tGenerocod_genero = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tGeneroPelicula_tGenero_tGenerocod_genero",
                        column: x => x.tGenerocod_genero,
                        principalTable: "tGenero",
                        principalColumn: "cod_genero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tGeneroPelicula_tPelicula_tPeliculacod_pelicula",
                        column: x => x.tPeliculacod_pelicula,
                        principalTable: "tPelicula",
                        principalColumn: "cod_pelicula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cod_usuario = table.Column<int>(type: "int", nullable: false),
                    txt_user = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txt_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txt_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txt_apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nro_doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cod_rol = table.Column<int>(type: "int", nullable: false),
                    sn_activo = table.Column<int>(type: "int", nullable: false),
                    tRolcod_rol = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUsers", x => x.Id);
                    table.UniqueConstraint("AK_tUsers_cod_usuario", x => x.cod_usuario);
                    table.ForeignKey(
                        name: "FK_tUsers_tRol_tRolcod_rol",
                        column: x => x.tRolcod_rol,
                        principalTable: "tRol",
                        principalColumn: "cod_rol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_tUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_tUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_tUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_tUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tUserPeliculaRent",
                columns: table => new
                {
                    cod_userPeliculaRent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio_alquiler = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fecha_alquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_devolucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    devuelta = table.Column<bool>(type: "bit", nullable: false),
                    cod_usuario = table.Column<int>(type: "int", nullable: false),
                    cod_pelicula = table.Column<int>(type: "int", nullable: false),
                    fecha_limite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tPeliculacod_pelicula = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUserPeliculaRent", x => x.cod_userPeliculaRent);
                    table.ForeignKey(
                        name: "FK_tUserPeliculaRent_tPelicula_tPeliculacod_pelicula",
                        column: x => x.tPeliculacod_pelicula,
                        principalTable: "tPelicula",
                        principalColumn: "cod_pelicula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tUserPeliculaRent_tUsers_tUserId",
                        column: x => x.tUserId,
                        principalTable: "tUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tUserPeliculaSell",
                columns: table => new
                {
                    cod_userPeliculaSell = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio_venta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cod_usuario = table.Column<int>(type: "int", nullable: false),
                    cod_pelicula = table.Column<int>(type: "int", nullable: false),
                    tUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tPeliculacod_pelicula = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUserPeliculaSell", x => x.cod_userPeliculaSell);
                    table.ForeignKey(
                        name: "FK_tUserPeliculaSell_tPelicula_tPeliculacod_pelicula",
                        column: x => x.tPeliculacod_pelicula,
                        principalTable: "tPelicula",
                        principalColumn: "cod_pelicula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tUserPeliculaSell_tUsers_tUserId",
                        column: x => x.tUserId,
                        principalTable: "tUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tGeneroPelicula_tGenerocod_genero",
                table: "tGeneroPelicula",
                column: "tGenerocod_genero");

            migrationBuilder.CreateIndex(
                name: "IX_tGeneroPelicula_tPeliculacod_pelicula",
                table: "tGeneroPelicula",
                column: "tPeliculacod_pelicula");

            migrationBuilder.CreateIndex(
                name: "IX_tUserPeliculaRent_tPeliculacod_pelicula",
                table: "tUserPeliculaRent",
                column: "tPeliculacod_pelicula");

            migrationBuilder.CreateIndex(
                name: "IX_tUserPeliculaRent_tUserId",
                table: "tUserPeliculaRent",
                column: "tUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tUserPeliculaSell_tPeliculacod_pelicula",
                table: "tUserPeliculaSell",
                column: "tPeliculacod_pelicula");

            migrationBuilder.CreateIndex(
                name: "IX_tUserPeliculaSell_tUserId",
                table: "tUserPeliculaSell",
                column: "tUserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "tUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_tUsers_tRolcod_rol",
                table: "tUsers",
                column: "tRolcod_rol");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "tUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tGeneroPelicula");

            migrationBuilder.DropTable(
                name: "tUserPeliculaRent");

            migrationBuilder.DropTable(
                name: "tUserPeliculaSell");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tGenero");

            migrationBuilder.DropTable(
                name: "tPelicula");

            migrationBuilder.DropTable(
                name: "tUsers");

            migrationBuilder.DropTable(
                name: "tRol");
        }
    }
}
