using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_DTO.ArticuloDTO
{
    public class ArticuloReadDTO
    {
        public Guid IdArticulo { get; set; }

        public string? Titulo { get; set; } 

        public string? Contenido { get; set; } 

        public string? Resumen { get; set; } 

        public string? ImagenPortada { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
