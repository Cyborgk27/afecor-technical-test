using TT.Application.Commons.Bases;
using TT.Application.Interfaces;
using TT.Domain.Entities;
using TT.Infrastructure.Persistences.Interfaces;

namespace TT.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<Client, int> _clientRepo;

        public ClientService(IGenericRepository<Client, int> clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task<BaseResponse<IEnumerable<Client>>> GetAvailableAsync()
        {
            var clients = (await _clientRepo.GetAllAsync())
                .Where(c => c.State == 1);
            return ResponseFactory.Success(clients, "Clientes disponibles");
        }
    }
}
