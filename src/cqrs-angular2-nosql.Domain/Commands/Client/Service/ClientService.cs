using cqrs_angular2_nosql.Domain.Commands;
using cqrs_angular2_nosql.Domain.Core.Bus;
using cqrs_angular2_nosql.Domain.Interfaces;
using cqrs_angular2_nosql.Domain.Models;

namespace cqrs_angular2_nosql.Domain.Service
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        private readonly IBus _bus;

        public ClientService(IRepository<Client> repository, IBus bus)
            : base(repository)
        {
            _bus = bus;
        }

        public void Register(RegisterClientCommand registerClientCommand)
        {
            _bus.SendCommand(registerClientCommand);
        }
    }
}
