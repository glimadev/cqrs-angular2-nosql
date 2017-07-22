using cqrs_angular2_nosql.Domain.Service;
using cqrs_angular2_nosql.VM.Common;
using cqrs_angular2_nosql.VM.In;
using cqrs_angular2_nosql.VM.Out;
using System;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Application
{
    public class ClientApp : IClientApp
    {
        readonly IClientService _clientService;

        public ClientApp(IClientService clientService)
        {
            _clientService = clientService;
        }

        public Task<ClientOutVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ClientOutVM> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public ResultServiceVM Post(ClientInsertInVM clientInsertInVM)
        {
            throw new NotImplementedException();
        }

        public ResultServiceVM Put(Guid id, ClientUpdateInVM clientUpdateInVM)
        {
            throw new NotImplementedException();
        }

        public ResultServiceVM Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
