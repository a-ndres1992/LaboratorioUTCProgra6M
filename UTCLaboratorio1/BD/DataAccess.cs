using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class DataAccess
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

        //REPRESENTACION DE RETORNO DE UNA LISTA
        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object Param= null, int? Timeout= null)
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


    }
}
