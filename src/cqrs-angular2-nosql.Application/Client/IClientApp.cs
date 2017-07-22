using cqrs_angular2_nosql.VM.Common;
using cqrs_angular2_nosql.VM.In;
using cqrs_angular2_nosql.VM.Out;
using System;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Application
{
    public interface IClientApp
    {
        //Async
        Task<ResultServiceDataVM<ClientListOutVM>> GetAll();
        Task<ResultServiceDataVM<ClientDetailOutVM>> Get(Guid id);

        //Sync
        ResultServiceVM Delete(Guid id);
        ResultServiceVM Post(ClientInsertInVM clientInsertInVM);
        ResultServiceVM Put(Guid id, ClientUpdateInVM clientUpdateInVM);
    }
}
