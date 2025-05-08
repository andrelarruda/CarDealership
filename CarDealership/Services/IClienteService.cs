using CarDealership.Models.ViewModels.Cliente;
using CarDealership.Models.ViewModels.Veiculo;

namespace CarDealership.Services
{
    public interface IClienteService
    {
        Task<List<ClienteViewModel>> ListarClientes();
    }
}
