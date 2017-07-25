using cqrs_angular2_nosql.Application;
using cqrs_angular2_nosql.VM.Common;
using cqrs_angular2_nosql.VM.In;
using cqrs_angular2_nosql.VM.Out;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace cqrs_angular2_nosql.Controllers
{
    public class ClientController : ApiController
    {
        readonly IClientApp _clientApp;

        public ClientController(IClientApp clientApp)
        {
            _clientApp = clientApp;
        }

        // GET api/values
        public async Task<ResultServiceDataVM<List<ClientListOutVM>>> GetAll()
        {
            return await _clientApp.GetAll();
        }

        // GET api/values/5
        public async Task<ResultServiceDataVM<ClientDetailOutVM>> Get(Guid id)
        {
            return await _clientApp.Get(id);
        }

        // POST api/values
        public async Task<ResultServiceVM> Post(ClientInsertInVM clientInsertInVM)
        {
            return await _clientApp.Post(clientInsertInVM);
        }

        // PUT api/values/5
        public async Task<ResultServiceVM> Put(Guid id, ClientUpdateInVM clientUpdateInVM)
        {
            clientUpdateInVM.Id = id;

            return await _clientApp.Update(clientUpdateInVM);
        }

        // DELETE api/values/5
        public async Task<ResultServiceVM> Delete(Guid id)
        {
            return await _clientApp.Delete(id);
        }
    }
}
