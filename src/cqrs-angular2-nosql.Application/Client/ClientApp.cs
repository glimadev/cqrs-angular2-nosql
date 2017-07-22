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

        public async Task<ResultServiceDataVM<ClientListOutVM>> GetAll()
        {
            return new ResultServiceDataVM<ClientListOutVM>().SetData(await _clientService.GetAllAsync());
        }

        public async Task<ResultServiceDataVM<ClientDetailOutVM>> Get(Guid id)
        {
            return new ResultServiceDataVM<ClientDetailOutVM>().SetData(await _clientService.FindByIdAsync(id.ToString()));
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
