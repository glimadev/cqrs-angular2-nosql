using cqrs_angular2_nosql.Domain.Commands;
using cqrs_angular2_nosql.Domain.Core.Notifications;
using cqrs_angular2_nosql.Domain.Interfaces;
using cqrs_angular2_nosql.Domain.Service;
using cqrs_angular2_nosql.Util.MapperUtils;
using cqrs_angular2_nosql.VM.Common;
using cqrs_angular2_nosql.VM.In;
using cqrs_angular2_nosql.VM.Out;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cqrs_angular2_nosql.Application
{
    public class ClientApp : IClientApp
    {
        readonly IDomainNotificationHandler<DomainNotification> _notifications;
        readonly IClientRepository _clientRepository;
        readonly IClientService _clientService;

        public ClientApp(IClientService clientService,
            IClientRepository clientRepository,
            IDomainNotificationHandler<DomainNotification> notifications)
        {
            _clientService = clientService;
            _clientRepository = clientRepository;
            _notifications = notifications;
        }

        public async Task<ResultServiceDataVM<List<ClientListOutVM>>> GetAll()
        {
            return new ResultServiceDataVM<List<ClientListOutVM>>().SetData(await _clientRepository.GetAllActiveAsync());
        }

        public async Task<ResultServiceDataVM<ClientDetailOutVM>> Get(Guid id)
        {
            return new ResultServiceDataVM<ClientDetailOutVM>().SetData(await _clientRepository.GetByIdAsync(id.ToString()));
        }

        public async Task<ResultServiceVM> Post(ClientInsertInVM clientInsertInVM)
        {
            ResultServiceVM resultServiceVM = new ResultServiceVM();

            await _clientService.Register(Mapper.Map<RegisterClientCommand>(clientInsertInVM));

            resultServiceVM.Messages.AddRange(_notifications.GetNotificationsMessages());

            return resultServiceVM;
        }

        public async Task<ResultServiceVM> Put(Guid id, ClientUpdateInVM clientUpdateInVM)
        {
            ResultServiceVM resultServiceVM = new ResultServiceVM();

            await _clientService.Update(Mapper.Map<UpdateClientCommand>(clientUpdateInVM));

            resultServiceVM.Messages.AddRange(_notifications.GetNotificationsMessages());

            return resultServiceVM;
        }

        public async Task<ResultServiceVM> Delete(Guid id)
        {
            ResultServiceVM resultServiceVM = new ResultServiceVM();

            await _clientService.Remove(new RemoveClientCommand(id));

            resultServiceVM.Messages.AddRange(_notifications.GetNotificationsMessages());

            return resultServiceVM;
        }
    }
}
