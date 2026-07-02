using AutoMapper;
using Capa_Datos.Repositorio.Contrato;
using Capa_DTO.AuthDTO;
using Capa_DTO.UsuarioDTO;
using Capa_Negocio.Servicios.Contrato;
using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Negocio.Servicios
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _repository;

        public AuthService(IMapper mapper, IGenericRepository<Usuario> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UsuarioReadDTO> Obtener(int? id)
        {
            try
            {
                if(id == null)
                {
                    throw new TaskCanceledException("El Id no puede ser vacio");
                }

                var usuario = await _repository.Obtener(
                    u =>
                    u.IdUsuario == id
                    );

                return _mapper.Map<UsuarioReadDTO>(usuario);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SesionDTO> ValidarCredenciales(string correo, string clave)
        {
            try
            {
                var query = await _repository.Consultar(
                    u =>
                    u.Correo == correo &&
                    u.Clave == clave
                    );

                var usuario = query.FirstOrDefault();

                if (usuario == null)
                {
                    throw new TaskCanceledException("Error en validacion de credenciales");
                }

                return _mapper.Map<SesionDTO>(usuario);

            }
            catch
            {
                throw;
            }
        }
    }
}
