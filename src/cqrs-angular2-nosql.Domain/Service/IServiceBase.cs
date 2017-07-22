using cqrs_angular2_nosql.Domain.Core.Models;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Domain.Service
{
    public interface IServiceBase<TEntity> where TEntity : IEntityBase
    {
        //Async
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(string keyValue);
        Task<TEntity> FirstOrDefaultAsync(Func<TEntity, bool> query);

        //Sync
        void AddOrUpdate(TEntity entity, RequestOptions requestOptions = null);
        void Delete(string id, RequestOptions requestOptions = null);
    }
}
