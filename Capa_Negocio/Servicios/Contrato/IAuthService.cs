using Capa_DTO.AuthDTO;
using Capa_DTO.UsuarioDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Negocio.Servicios.Contrato
{
    public interface IAuthService
    {
        Task<SesionDTO> ValidarCredenciales(string correo, string clave);
        Task<UsuarioReadDTO> Obtener(int? id);
    }
}
