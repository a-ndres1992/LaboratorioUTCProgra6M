using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IProveedorService
    {
        Task<DBEntity> Create(ProovedorEntity entity);
        Task<DBEntity> Delete(ProovedorEntity entity);
        Task<IEnumerable<ProovedorEntity>> Get();
        Task<ProovedorEntity> GetById(ProovedorEntity entity);
        Task<DBEntity> Update(ProovedorEntity entity);
    }

    public class ProveedorService : IProveedorService
    {
        private readonly IDataAccess sql;

        public ProveedorService(IDataAccess _sql)
        {
            sql = _sql;  
        }

        #region MetodosCrud

        //Metodo Get
        public async Task<IEnumerable<ProovedorEntity>> Get()
        {

            try
            {
                var result = sql.QueryAsync<ProovedorEntity>("dbo.ProveedorObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO GET BY ID

        public async Task<ProovedorEntity> GetById(ProovedorEntity entity)
        {

            try
            {
                var result = sql.QueryFirstAsync<ProovedorEntity>("dbo.ProveedorObtener", new { entity.IdProovedor });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO CREATE

        public async Task<DBEntity> Create(ProovedorEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("dbo.ProveedorInsertar", new
                {
                    entity.Identificacion
                   ,
                    entity.Nombre
                   ,
                    entity.PrimerApellido
                   ,
                    entity.SegundoApellido
                   ,
                    entity.Edad
                   ,
                    entity.FechaNacimiento
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO Update

        public async Task<DBEntity> Update(ProovedorEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("dbo.ProveedorActualizar", new
                {
                    entity.IdProovedor
                   ,
                    entity.Identificacion
                   ,
                    entity.Nombre
                   ,
                    entity.PrimerApellido
                   ,
                    entity.SegundoApellido
                   ,
                    entity.Edad
                   ,
                    entity.FechaNacimiento
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO DELETE

        public async Task<DBEntity> Delete(ProovedorEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("dbo.ProveedorEliminar", new
                {
                    entity.IdProovedor
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion

    }
}

