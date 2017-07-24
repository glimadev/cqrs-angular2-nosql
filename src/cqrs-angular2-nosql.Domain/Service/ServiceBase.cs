using cqrs_angular2_nosql.Domain.Core.Models;
using cqrs_angular2_nosql.Domain.Interfaces;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Domain.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class, IEntityBase
    {
        readonly IRepository<TEntity> _repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Func<TEntity, bool> query)
        {
            return await _repository.FirstOrDefaultAsync(query);
        }

        public async Task<TEntity> FindByIdAsync(string keyValue)
        {
            return await _repository.GetByIdAsync(keyValue);
        }

        public void AddOrUpdate(TEntity entity, RequestOptions requestOptions = null)
        {
            _repository.AddOrUpdateAsync(entity, requestOptions);
        }

        public void Delete(string id, RequestOptions requestOptions = null)
        {
            _repository.DeleteLogicAsync(id, requestOptions);
        }
    }
}
