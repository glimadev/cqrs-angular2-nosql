using cqrs_angular2_nosql.Application;
using cqrs_angular2_nosql.VM.Common;
using cqrs_angular2_nosql.VM.In;
using cqrs_angular2_nosql.VM.Out;
using System;
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
        public async Task<ClientOutVM> GetAll()
        {
            return await _clientApp.GetAll();
        }

        // GET api/values/5
        public async Task<ClientOutVM> Get(Guid id)
        {
            return await _clientApp.Get(id);
        }

        // POST api/values
        public ResultServiceVM Post(ClientInsertInVM clientInsertInVM)
        {
            return _clientApp.Post(clientInsertInVM);
        }

        // PUT api/values/5
        public ResultServiceVM Put(Guid id, ClientUpdateInVM clientUpdateInVM)
        {
            return _clientApp.Put(id, clientUpdateInVM);
        }

        // DELETE api/values/5
        public ResultServiceVM Delete(Guid id)
        {
            return _clientApp.Delete(id);
        }
    }
}
