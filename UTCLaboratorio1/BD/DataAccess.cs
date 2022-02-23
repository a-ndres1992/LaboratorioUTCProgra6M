using Dapper;
using Dapper.Mapper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration config;

        //Constructor
        public DataAccess(IConfiguration _Config)
        {
            //VARIABLE QUE ME PERMITE GUARDAR LA CONFIGURACION DE CONECCION A BD
            config = _Config;
        }

        //METODO PARA REALIZAR LA CONECCION A LA BASE DE DATOS
        public SqlConnection DbConection => new SqlConnection(
            new SqlConnectionStringBuilder(config.GetConnectionString("Conn")).ConnectionString);

        //METODO DE RETORNO DE UNA LISTA
        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO DE RETORNO DE UNA LISTA DYNAMICA
        public async Task<IEnumerable<dynamic>> QueryAsync(string sp, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO DE RETORNO DE UNA LISTA DE UNA ENTIDAD PERO RELACIONADA A OTRA ENTIDAD(COMO UN TRIGGER)
        public async Task<IEnumerable<T>> QueryAsync<T, B>(string sp, string split, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout, splitOn: split);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C>(string sp, string split, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout, splitOn: split);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D>(string sp, string split, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout, splitOn: split);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E>(string sp, string split, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout, splitOn: split);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F>(string sp, string split, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E, F>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout, splitOn: split);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F, G>(string sp, string split, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E, F, G>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout, splitOn: split);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //METODO DE RETORNO DE UN SOLO REGISTRO
        public async Task<T> QueryFirstAsync<T>(string sp, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryFirstOrDefaultAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        //METODO DE RETORNo DE LA GESTION DE MENSAJES DE ERROR 
        public async Task<DBEntity> ExecuteAsync(string sp, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConection)
                {
                    await exec.OpenAsync();
                    var result = await exec.ExecuteReaderAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout);
                    await result.ReadAsync();
                    return new()
                    {
                        CodeError = result.GetInt32(0),
                        MsgError = result.GetString(1)
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
