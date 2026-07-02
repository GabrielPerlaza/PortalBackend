using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos
{
    public class Articulo
    {
        [Key] 
        public Guid IdArticulo { get; set; }
        public string? Titulo { get; set; }
        public string? Slug { get; set; }
        public string? Resumen { get; set; }
        public string? Contenido { get; set; }
        public string? ImagenPortada { get; set; }
        public bool? Publicado { get; set; }
        public DateTime? FechaPublicacion { get; set; } 
        public DateTime? FechaCreacion { get; set; } 


        // Relaciones

        public Guid? IdCategoria { get; set; }
        public Categoria? Categoria { get; set; }
        public Guid? IdAutor { get; set; }
        public Usuario? Autor { get; set; }
        public ICollection<Etiqueta>? Etiquetas { get; set; }

    }
}
