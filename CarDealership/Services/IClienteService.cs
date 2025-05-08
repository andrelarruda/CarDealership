using CarDealership.Models;
using CarDealership.Models.ViewModels.Cliente;
using CarDealership.Models.ViewModels.Veiculo;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Services
{
    public interface IClienteService
    {
        Task<Cliente> Criar(ClienteViewModel model);
        Task<ActionResult> ConsultarPorCPF(string cpf);
        Task<List<ClienteViewModel>> ListarClientes();
    }
}
