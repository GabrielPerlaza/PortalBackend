using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Capa_Datos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Etiqueta",
                columns: table => new
                {
                    IdEtiqueta = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiqueta", x => x.IdEtiqueta);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Clave = table.Column<string>(type: "text", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    IdArticulo = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    Resumen = table.Column<string>(type: "text", nullable: true),
                    Contenido = table.Column<string>(type: "text", nullable: true),
                    ImagenPortada = table.Column<string>(type: "text", nullable: true),
                    Publicado = table.Column<bool>(type: "boolean", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdCategoria = table.Column<Guid>(type: "uuid", nullable: true),
                    CategoriaIdCategoria = table.Column<Guid>(type: "uuid", nullable: true),
                    IdAutor = table.Column<Guid>(type: "uuid", nullable: true),
                    AutorIdUsuario = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_Articulo_Categoria_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK_Articulo_Usuario_AutorIdUsuario",
                        column: x => x.AutorIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "ArticuloEtiqueta",
                columns: table => new
                {
                    ArticulosIdArticulo = table.Column<Guid>(type: "uuid", nullable: false),
                    EtiquetasIdEtiqueta = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloEtiqueta", x => new { x.ArticulosIdArticulo, x.EtiquetasIdEtiqueta });
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Articulo_ArticulosIdArticulo",
                        column: x => x.ArticulosIdArticulo,
                        principalTable: "Articulo",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Etiqueta_EtiquetasIdEtiqueta",
                        column: x => x.EtiquetasIdEtiqueta,
                        principalTable: "Etiqueta",
                        principalColumn: "IdEtiqueta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_AutorIdUsuario",
                table: "Articulo",
                column: "AutorIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_CategoriaIdCategoria",
                table: "Articulo",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_EtiquetasIdEtiqueta",
                table: "ArticuloEtiqueta",
                column: "EtiquetasIdEtiqueta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloEtiqueta");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Etiqueta");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
