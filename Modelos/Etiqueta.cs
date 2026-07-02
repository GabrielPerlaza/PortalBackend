using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos
{
    public class Etiqueta
    {
        [Key]
        public Guid IdEtiqueta { get; set; }
        public string? Nombre { get; set; }
        public string? Slug { get; set; }
        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();

    }
}
