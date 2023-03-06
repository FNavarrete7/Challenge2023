using Dapper.Contrib.Extensions;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string _connectionString;
        public Repository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name }"; };
            _connectionString = connectionString;
        }
        public bool Delete(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Delete(entity);
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await (Task<bool>)connection.DeleteAsync(entity);
            }
        }

        public T GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<T>(id);
            }
        }



        public async Task<T> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.GetAsync<T>(id);
            }
        }


        public IEnumerable<T> GetList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<T>();
            }
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.GetAllAsync<T>();
            }
        }

        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public async Task<int> InsertAsync(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await (Task<int>)connection.InsertAsync(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Update(entity);
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await (Task<bool>)connection.UpdateAsync(entity);
            }
        }
    }
}
