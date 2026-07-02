using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_DTO.AuthDTO
{
    public class UsuarioReadDTO
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
