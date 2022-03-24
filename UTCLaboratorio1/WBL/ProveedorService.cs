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
        Task<DBEntity> Create(ProveedorEntity entity);
        Task<DBEntity> Delete(ProveedorEntity entity);
        Task<IEnumerable<ProveedorEntity>> Get();
        Task<ProveedorEntity> GetById(ProveedorEntity entity);
        Task<DBEntity> Update(ProveedorEntity entity);
        Task<IEnumerable<ProveedorEntity>> GetLista();
    }

    public class ProveedorService : IProveedorService
    {
        private readonly IDataAccess sql;

        public ProveedorService(IDataAccess _sql)
        {
            sql = _sql;  
        }

        #region MetodosLista

        //Metodo GetLista
        public async Task<IEnumerable<ProveedorEntity>> GetLista()
        {

            try
            {
                var result = sql.QueryAsync<ProveedorEntity>("dbo.ProveedorLista");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region MetodosCrud



        //Metodo Get
        public async Task<IEnumerable<ProveedorEntity>> Get()
        {

            try
            {
                var result = sql.QueryAsync<ProveedorEntity>("dbo.ProveedorObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO GET BY ID

        public async Task<ProveedorEntity> GetById(ProveedorEntity entity)
        {

            try
            {
                var result = sql.QueryFirstAsync<ProveedorEntity>("dbo.ProveedorObtener", new { entity.IdProveedor });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO CREATE

        public async Task<DBEntity> Create(ProveedorEntity entity)
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

        public async Task<DBEntity> Update(ProveedorEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("dbo.ProveedorActualizar", new
                {
                    entity.IdProveedor
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

        public async Task<DBEntity> Delete(ProveedorEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("dbo.ProveedorEliminar", new
                {
                    entity.IdProveedor
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

