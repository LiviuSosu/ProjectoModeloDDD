using ProjectDDD.Application.Interfaces;
using ProjectDDD.Domain.Entities;
using ProjectDDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ProjectDDD.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClientService _clientService;

        public ClienteAppService(IClientService clientService) : base(clientService)
        {
            _clientService = clientService;
        }

        public IEnumerable<Cliente> ObterClientsEspecials()
        {
            return _clientService.ObterClientsEspecials(_clientService.GetAll());
        }
    }
}
