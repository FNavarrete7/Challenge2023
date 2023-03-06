using Dapper;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class ContactoRepository : Repository<Contacto>, IContactoRepository
    {
        public ContactoRepository(string connectionString) : base(connectionString)
        {
        }

        public ResultPagination<Contacto> GetAllContacto(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                IEnumerable<Contacto> result = connection.Query<Contacto>("dbo.GetAllContacto", parameters, commandType: System.Data.CommandType.StoredProcedure);
                var cantidad = connection.ExecuteScalar("dbo.GetAllContactoCount", null, commandType: System.Data.CommandType.StoredProcedure);

                return new ResultPagination<Contacto>()
                {
                    CantidadResultado = Int32.Parse(cantidad.ToString()),
                    ListaResultado = result.AsList()
                };
            }
        }
    }
}
