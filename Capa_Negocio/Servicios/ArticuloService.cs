using AutoMapper;
using Capa_Datos.Repositorio;
using Capa_Datos.Repositorio.Contrato;
using Capa_DTO.ArticuloDTO;
using Capa_Negocio.Servicios.Contrato;
using Modelos;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capa_Negocio.Servicios
{
    public class ArticuloService : IArticuloService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Articulo> _repository;

        public ArticuloService(IMapper mapper, IGenericRepository<Articulo> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ArticuloPreviewDTO>> Lista()
        {
            try
            {
                var query = await _repository.Consultar();
                var articulos = query.ToList();
                return _mapper.Map<List<ArticuloPreviewDTO>>(articulos);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ArticuloReadDTO> Obtener(Guid Id)
        {
            try
            {
                if(Id == Guid.Empty)
                {
                    throw new TaskCanceledException("El Id no puede ser vacio");
                }

                var articulo =  await _repository.Obtener(u =>
                    u.IdArticulo == Id
                    );

                return _mapper.Map<ArticuloReadDTO>(articulo);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ArticuloPostedDTO> Crear(ArticuloPostedDTO modelo)
        {
            try
            {
                var articulo = _mapper.Map<Articulo>(modelo);
                Console.WriteLine("DTO Imagen:");
                Console.WriteLine(modelo.ImagenPortada);

                Console.WriteLine("Entidad Imagen:");
                Console.WriteLine(articulo.ImagenPortada);
                articulo.FechaCreacion = DateTime.UtcNow;

                Console.WriteLine($"FechaCreacion antes de guardar: {articulo.FechaCreacion}");

                var articuloCreado = await _repository.Crear(articulo);


                if (articulo.IdArticulo == Guid.Empty)
                {
                    throw new TaskCanceledException("No se pudo crear el articulo");
                }
               
                    return _mapper.Map<ArticuloPostedDTO>(articulo);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ArticuloUpdateDTO modelo)
        {
            try
            {
                var articulo = _mapper.Map<ArticuloUpdateDTO>(modelo);

                var articuloEncontrado = await _repository.Obtener(u =>
                u.IdArticulo == articulo.IdArticulo
                    );

                if (articuloEncontrado == null)
                {
                    throw new TaskCanceledException("No se pudo encontrar el articulo");
                }

                articuloEncontrado.Titulo = articulo.Titulo;
                articuloEncontrado.Contenido = articulo.Contenido;
                articuloEncontrado.Resumen = articulo.Resumen;
                articuloEncontrado.IdAutor = articulo.IdAutor;
                articuloEncontrado.IdCategoria = articulo.IdCategoria;
                articuloEncontrado.FechaPublicacion = DateTime.UtcNow; 
                articuloEncontrado.ImagenPortada = articulo.ImagenPortada;

                bool respuesta = await _repository.Editar(articuloEncontrado);

                

                if(!respuesta)
                {
                    throw new TaskCanceledException("No se pudo editar el articulo");
                }
                return respuesta;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Guid Id)
        {
            try
            {
                var articuloEncontrado = await _repository.Obtener(u =>
                    u.IdArticulo == Id
                    );
                if (articuloEncontrado == null)
                {
                    throw new TaskCanceledException("No se pudo encontrar el articulo");
                }

                bool respuesta = await _repository.Eliminar(articuloEncontrado);

                return respuesta;
            }
            catch
            {
                throw;
            }

        }

        
    }
}
