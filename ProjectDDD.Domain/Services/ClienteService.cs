using ProjectDDD.Domain.Entities;
using ProjectDDD.Domain.Interfaces;
using ProjectDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDDD.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClientService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterClientsEspecials(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.ClienteEspecial(c));
        }
    }
}
