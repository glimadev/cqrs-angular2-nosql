using cqrs_angular2_nosql.Domain.Interfaces;
using cqrs_angular2_nosql.Domain.Models;

namespace cqrs_angular2_nosql.Infra.Data.Repository
{
    /// <summary>
    /// Client como supertipo do repository
    /// </summary>
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository()
            : base("ClientCollection")
        {
        }
    }
}
