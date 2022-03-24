using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IContactoService
    {
        Task<DBEntity> Create(ContactoEntity entity);
        Task<DBEntity> Delete(ContactoEntity entity);
        Task<IEnumerable<ContactoEntity>> Get();
        Task<ContactoEntity> GetById(ContactoEntity entity);
        Task<DBEntity> Update(ContactoEntity entity);
    }

    public class ContactoService : IContactoService
    {
        private readonly IDataAccess sql;

        public ContactoService(IDataAccess _sql)
        {
            sql = _sql;
        }




        #region MetodosCrud

        //Metodo Get
        public async Task<IEnumerable<ContactoEntity>> Get()
        {

            try
            {
                var result = sql.QueryAsync<ContactoEntity, ProveedorEntity>("dbo.ContactoObtener", "IdContacto", "IdProveedor");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO GET BY ID

        public async Task<ContactoEntity> GetById(ContactoEntity entity)
        {

            try
            {
                var result = sql.QueryFirstAsync<ContactoEntity>("dbo.ContactoObtener", new { entity.IdContacto });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO CREATE

        public async Task<DBEntity> Create(ContactoEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("dbo.ContactoInsertar", new
                {
                    entity.Identificacion

                    ,
                    entity.IdContacto
                   ,
                    entity.Nombre
                   ,
                    entity.PrimerApellido
                   ,
                    entity.SegundoApellido

                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO Update

        public async Task<DBEntity> Update(ContactoEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("dbo.ContactoActualizar", new
                {
                    entity.IdContacto
                   ,
                    entity.Identificacion
                   ,
                    entity.Nombre
                   ,
                    entity.PrimerApellido
                   ,
                    entity.SegundoApellido

                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO DELETE

        public async Task<DBEntity> Delete(ContactoEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("dbo.ContactoEliminar", new
                {
                    entity.IdContacto
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
