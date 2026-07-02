using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelos
{
    public class Categoria
    {
        [Key]
        public Guid IdCategoria { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
