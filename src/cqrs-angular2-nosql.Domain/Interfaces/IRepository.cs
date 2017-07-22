using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllActiveAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> FirstOrDefaultAsync(Func<T, bool> predicate);
        Task<IQueryable<T>> QueryAsync();
        Task<T> AddOrUpdateAsync(T entity, RequestOptions requestOptions = null);
        Task<bool> DeleteLogicAsync(string id, RequestOptions requestOptions = null);
    }
}
