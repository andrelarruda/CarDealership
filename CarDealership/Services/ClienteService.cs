using AutoMapper;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Cliente;
using CarDealership.Models.ViewModels.Veiculo;
using CarDealership.Repositories;
using NuGet.Protocol.Core.Types;

namespace CarDealership.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ClienteViewModel>> ListarClientes()
        {
            List<Cliente> listaVeiculos = await _repository.GetAllAsync();
            return listaVeiculos.Select(f => _mapper.Map<ClienteViewModel>(f)).ToList();
        }
    }
}
