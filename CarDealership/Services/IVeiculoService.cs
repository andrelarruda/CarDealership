using CarDealership.Models.ViewModels.Fabricante;
using CarDealership.Models.ViewModels.Veiculo;

namespace CarDealership.Services
{
    public interface IVeiculoService
    {
        Task<List<VeiculoViewModel>> ListarVeiculos();
        Task<VeiculoViewModel> ObterVeiculoViewModel();

        Task<VeiculoViewModel> ListarPorId(int id);

        Task<VeiculoViewModel> Criar(VeiculoViewModel veiculo);
        Task<VeiculoViewModel> Editar(VeiculoViewModel veiculo);
        Task Excluir(int id);
    }
}
