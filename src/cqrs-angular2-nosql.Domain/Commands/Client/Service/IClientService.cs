using cqrs_angular2_nosql.Domain.Commands;
using cqrs_angular2_nosql.Domain.Models;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Domain.Service
{
    public interface IClientService : IServiceBase<Client>
    {
        Task Register(RegisterClientCommand registerClientCommand);
        Task Update(UpdateClientCommand updateClientCommand);
        Task Remove(RemoveClientCommand removeClientCommand);
    }
}
