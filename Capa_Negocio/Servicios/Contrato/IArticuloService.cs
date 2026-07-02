using Capa_DTO.ArticuloDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Negocio.Servicios.Contrato
{
    public interface IArticuloService
    {
        Task<List<ArticuloPreviewDTO>> Lista();
        Task<ArticuloReadDTO> Obtener(Guid Id);
        Task<ArticuloPostedDTO> Crear(ArticuloPostedDTO modelo);
        Task<bool> Editar(ArticuloUpdateDTO modelo);
        Task<bool> Eliminar(Guid Id);
    }
}
