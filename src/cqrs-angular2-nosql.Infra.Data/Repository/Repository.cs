using cqrs_angular2_nosql.Infra.Data.Context;
using cqrs_angular2_nosql.Infra.Data.Repository.Interfaces;
using cqrs_angular2_nosql.Util;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase
    {
        private readonly DocumentClient _client;
        private readonly string _databaseId;

        private readonly AsyncLazy<Database> _database;
        private AsyncLazy<DocumentCollection> _collection;

        private readonly string _collectionName;

        private readonly string _repositoryIdentityProperty = "id";
        private readonly string _defaultIdentityPropertyName = "id";

        public Repository(string collectionName, string databaseId = null, Expression<Func<T, object>> idNameFactory = null)
        {
            DocumentDBContext documentDBDataContext = new DocumentDBContext();

            _client = documentDBDataContext.Client;

            _databaseId = databaseId == null ? ConfigurationManager.AppSettings["DatabaseName"] : databaseId;

            _database = new AsyncLazy<Database>(async () => await GetOrCreateDatabaseAsync());

            _collection = new AsyncLazy<DocumentCollection>(async () => await GetOrCreateCollectionAsync());

            _collectionName = collectionName;

            _repositoryIdentityProperty = TryGetIdProperty(idNameFactory);
        }
        public async Task<List<T>> GetAllAsync()
        {
            return _client.CreateDocumentQuery<T>((await _collection).SelfLink).AsEnumerable().ToList();
        }

        public async Task<List<T>> GetAllActiveAsync()
        {
            return _client.CreateDocumentQuery<T>((await _collection).SelfLink).Where(x => x.Actived).AsEnumerable().ToList();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var retVal = await GetDocumentByIdAsync(id);
            return (T)(dynamic)retVal;
        }

        public async Task<T> FirstOrDefaultAsync(Func<T, bool> predicate)
        {
            return
                _client.CreateDocumentQuery<T>((await _collection).DocumentsLink)
                    .Where(predicate)
                    .AsEnumerable()
                    .FirstOrDefault();
        }

        public async Task<IQueryable<T>> QueryAsync()
        {
            return _client.CreateDocumentQuery<T>((await _collection).DocumentsLink);
        }

        public async Task<T> AddOrUpdateAsync(T entity, RequestOptions requestOptions = null)
        {
            T upsertedEntity;

            entity.Actived = true;

            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.DateCreated = DateTime.Now.ToString();
            }
            else
            {
                entity.DateEdited = DateTime.Now.ToString();
            }

            var upsertedDoc = await _client.UpsertDocumentAsync((await _collection).SelfLink, entity, requestOptions);

            upsertedEntity = JsonConvert.DeserializeObject<T>(upsertedDoc.Resource.ToString());

            return upsertedEntity;
        }

        public async Task<bool> DeleteLogicAsync(string id, RequestOptions requestOptions = null)
        {
            bool isSuccess = false;

            var upsertedEntity = await GetByIdAsync(id);

            if (upsertedEntity != null)
            {
                upsertedEntity.Actived = false;

                var result = await _client.UpsertDocumentAsync((await _collection).SelfLink, upsertedEntity, requestOptions);

                isSuccess = result.StatusCode == HttpStatusCode.NoContent;
            }

            return isSuccess;
        }

        private string TryGetIdProperty(Expression<Func<T, object>> idNameFactory)
        {
            Type entityType = typeof(T);

            var properties = entityType.GetProperties();

            if (idNameFactory != null)
            {
                var expr = GetMemberExpression(idNameFactory);

                MemberInfo customPropertyInfo = expr.Member;

                EnsurePropertyHasJsonAttributeWithCorrectPropertyName(customPropertyInfo);

                return customPropertyInfo.Name;
            }

            var idProperty = properties.SingleOrDefault(p => p.Name == _defaultIdentityPropertyName);

            if (idProperty != null)
            {
                return idProperty.Name;
            }

            idProperty = properties.SingleOrDefault(p => p.Name == "Id");

            if (idProperty != null)
            {
                EnsurePropertyHasJsonAttributeWithCorrectPropertyName(idProperty);

                return idProperty.Name;
            }

            throw new ArgumentException("Crie uma propriedade \"id\" para sua entitade");
        }

        private void EnsurePropertyHasJsonAttributeWithCorrectPropertyName(MemberInfo idProperty)
        {
            var attributes = idProperty.GetCustomAttributes(typeof(JsonPropertyAttribute), true);
            if (!(attributes.Length == 1 &&
                ((JsonPropertyAttribute)attributes[0]).PropertyName == _defaultIdentityPropertyName))
            {
                throw new ArgumentException(
                        string.Format(
                            "\"{0}\" propriedade precisa estar usando a notação JsonAttirbute com o nome de propriedade \"id\"",
                            idProperty.Name));
            }
        }

        private async Task<Document> GetDocumentByIdAsync(object id)
        {
            return _client.CreateDocumentQuery<Document>((await _collection).SelfLink).Where(d => d.Id == id.ToString()).AsEnumerable().FirstOrDefault();
        }

        private async Task<DocumentCollection> GetOrCreateCollectionAsync()
        {
            DocumentCollection collection = _client.CreateDocumentCollectionQuery((await _database).SelfLink).Where(c => c.Id == _collectionName).ToArray().FirstOrDefault();

            if (collection == null)
            {
                collection = new DocumentCollection { Id = _collectionName };

                collection = await _client.CreateDocumentCollectionAsync((await _database).SelfLink, collection);
            }

            return collection;
        }

        private async Task<Database> GetOrCreateDatabaseAsync()
        {
            Database database = _client.CreateDatabaseQuery()
                .Where(db => db.Id == _databaseId).ToArray().FirstOrDefault();

            if (database == null)
            {
                database = await _client.CreateDatabaseAsync(
                    new Database { Id = _databaseId });
            }

            return database;
        }

        private MemberExpression GetMemberExpression<T>(Expression<Func<T, object>> expr)
        {
            var member = expr.Body as MemberExpression;
            var unary = expr.Body as UnaryExpression;
            return member ?? (unary != null ? unary.Operand as MemberExpression : null);
        }

        public void Dispose()
        {
            _client.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
