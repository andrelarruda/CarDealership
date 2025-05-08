using AutoMapper;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Cliente;
using CarDealership.Models.ViewModels.Veiculo;
using CarDealership.Repositories;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Cliente> Criar(ClienteViewModel model)
        {
            return await _repository.Create(_mapper.Map<Cliente>(model));
        }

        public async Task<ActionResult> ConsultarPorCPF(string cpf)
        {
            try
            {
                Cliente cliente = await _repository.GetByCPF(cpf.Replace("-", "").Replace(".", ""));
                if (cliente != null)
                {
                    return new JsonResult(new { 
                        id = cliente.Id,
                        nome = cliente.Nome,
                        cpf = cliente.CPF,
                        telefone = cliente.Telefone,
                    });
                }
                return new JsonResult(new { });
            } catch(Exception ex)
            {
                throw new Exception($"Houve um erro ao buscar cliente por CPF: {ex.Message}");
            }
        }



        public async Task<List<ClienteViewModel>> ListarClientes()
        {
            List<Cliente> listaVeiculos = await _repository.GetAllAsync();
            return listaVeiculos.Select(f => _mapper.Map<ClienteViewModel>(f)).ToList();
        }
    }
}
