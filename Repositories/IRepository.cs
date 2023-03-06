using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T> where T : class
    {
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        int Insert(T entity);
        Task<int> InsertAsync(T entity);
        IEnumerable<T> GetList();
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
    }
}
