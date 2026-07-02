using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Capa_Datos.DataBaseContext
{
    public class PortalContext : DbContext
    {
        public PortalContext(DbContextOptions<PortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("ArticuloEtiqueta", b =>
            {
                b.Property<Guid>("ArticulosIdArticulo")
                    .HasColumnType("uuid");

                b.Property<Guid>("EtiquetasIdEtiqueta")
                    .HasColumnType("uuid");

                b.HasKey("ArticulosIdArticulo", "EtiquetasIdEtiqueta");

                b.HasIndex("EtiquetasIdEtiqueta");

                b.ToTable("ArticuloEtiqueta");
            });

            modelBuilder.Entity("Modelos.Articulo", b =>
            {
                b.Property<Guid>("IdArticulo")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<int?>("AutorIdUsuario")
                    .HasColumnType("integer");

                b.Property<Guid?>("CategoriaIdCategoria")
                    .HasColumnType("uuid");

                b.Property<string>("Contenido")
                    .HasColumnType("text");

                b.Property<DateTime?>("FechaCreacion")
                    .HasColumnType("timestamp with time zone");

                b.Property<DateTime?>("FechaPublicacion")
                    .HasColumnType("timestamp with time zone");

                b.Property<Guid?>("IdAutor")
                    .HasColumnType("uuid");

                b.Property<Guid?>("IdCategoria")
                    .HasColumnType("uuid");

                b.Property<string>("ImagenPortada")
                    .HasColumnType("text");

                b.Property<bool?>("Publicado")
                    .HasColumnType("boolean");

                b.Property<string>("Resumen")
                    .HasColumnType("text");

                b.Property<string>("Slug")
                    .HasColumnType("text");

                b.Property<string>("Titulo")
                    .HasColumnType("text");

                b.HasKey("IdArticulo");

                b.HasIndex("AutorIdUsuario");

                b.HasIndex("CategoriaIdCategoria");

                b.ToTable("Articulo");
            });

            modelBuilder.Entity("Modelos.Categoria", b =>
            {
                b.Property<Guid>("IdCategoria")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("Descripcion")
                    .HasColumnType("text");

                b.Property<string>("Nombre")
                    .HasColumnType("text");

                b.HasKey("IdCategoria");

                b.ToTable("Categoria");
            });

            modelBuilder.Entity("Modelos.Etiqueta", b =>
            {
                b.Property<Guid>("IdEtiqueta")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<string>("Nombre")
                    .HasColumnType("text");

                b.Property<string>("Slug")
                    .HasColumnType("text");

                b.HasKey("IdEtiqueta");

                b.ToTable("Etiqueta");
            });

            modelBuilder.Entity("Modelos.Usuario", b =>
            {
                b.Property<int>("IdUsuario")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUsuario"));

                b.Property<string>("Clave")
                    .HasColumnType("text");

                b.Property<string>("Correo")
                    .HasColumnType("text");

                b.Property<DateTime?>("FechaRegistro")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Nombre")
                    .HasColumnType("text");

                b.HasKey("IdUsuario");

                b.ToTable("Usuario");
            });

            modelBuilder.Entity("ArticuloEtiqueta", b =>
            {
                b.HasOne("Modelos.Articulo", null)
                    .WithMany()
                    .HasForeignKey("ArticulosIdArticulo")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Modelos.Etiqueta", null)
                    .WithMany()
                    .HasForeignKey("EtiquetasIdEtiqueta")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Modelos.Articulo", b =>
            {
                b.HasOne("Modelos.Usuario", "Autor")
                    .WithMany()
                    .HasForeignKey("AutorIdUsuario");

                b.HasOne("Modelos.Categoria", "Categoria")
                    .WithMany("Articulos")
                    .HasForeignKey("CategoriaIdCategoria");

                b.Navigation("Autor");

                b.Navigation("Categoria");
            });

            modelBuilder.Entity("Modelos.Categoria", b =>
            {
                b.Navigation("Articulos");
            });

        }

        }
}
