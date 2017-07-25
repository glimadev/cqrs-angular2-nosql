using cqrs_angular2_nosql.VM.Common;
using cqrs_angular2_nosql.VM.In;
using cqrs_angular2_nosql.VM.Out;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Application
{
    public interface IClientApp
    {
        Task<ResultServiceDataVM<List<ClientListOutVM>>> GetAll();
        Task<ResultServiceDataVM<ClientDetailOutVM>> Get(Guid id);

        Task<ResultServiceVM> Post(ClientInsertInVM clientInsertInVM);
        Task<ResultServiceVM> Update(ClientUpdateInVM clientUpdateInVM);
        Task<ResultServiceVM> Delete(Guid id);
    }
}
