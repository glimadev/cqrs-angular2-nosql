using cqrs_angular2_nosql.Domain.Commands;
using cqrs_angular2_nosql.Domain.Models;

namespace cqrs_angular2_nosql.Domain.Service
{
    public interface IClientService : IServiceBase<Client>
    {
        void Register(RegisterClientCommand registerClientCommand);
    }
}
