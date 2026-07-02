using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_DTO.ArticuloDTO
{
    public class ArticuloUpdateDTO
    {
        public Guid IdArticulo { get; set; }
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public string? Resumen { get; set; }
        public Guid? IdAutor { get; set; }
        public Guid? IdCategoria { get; set; }
        public List<Guid>? IdEtiquetas { get; set; }
        public string? ImagenPortada { get; set; }

    }
}
