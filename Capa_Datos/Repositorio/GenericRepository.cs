using Capa_Datos.DataBaseContext;
using Capa_Datos.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Capa_Datos.Repositorio
{
    public class GenericRepository<Tmodelo> : IGenericRepository<Tmodelo> where Tmodelo : class
    {
        private readonly PortalContext _dbContext;

        public  GenericRepository(PortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tmodelo> Obtener(Expression<Func<Tmodelo, bool>> Filtro)
        {
            try
            {
                Tmodelo modelo = await _dbContext.Set<Tmodelo>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(Filtro);
                return modelo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IQueryable<Tmodelo>> Consultar(Expression<Func<Tmodelo, bool>> Filtro = null)
        {
            try
            {
                IQueryable<Tmodelo> query = Filtro == null ? _dbContext.Set<Tmodelo>() : _dbContext.Set<Tmodelo>().Where(Filtro);
                return query;
            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        public async Task<Tmodelo> Crear(Tmodelo modelo)
        {
            try
            {
                await _dbContext.Set<Tmodelo>().AddAsync(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<bool> Editar(Tmodelo modelo)
        {
            try
            {
                _dbContext.Set<Tmodelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<bool> Eliminar(Tmodelo modelo)
        {
            try
            {
                _dbContext.Set<Tmodelo>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
