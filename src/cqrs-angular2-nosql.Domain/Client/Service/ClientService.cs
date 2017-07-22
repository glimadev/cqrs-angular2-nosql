using cqrs_angular2_nosql.Domain.Interfaces;
using cqrs_angular2_nosql.Domain.Models;

namespace cqrs_angular2_nosql.Domain.Service
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        public ClientService(IRepository<Client> repository)
            : base(repository)
        {
        }
    }
}
