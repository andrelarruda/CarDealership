using CarDealership.Models.ViewModels.Concessionaria;
using CarDealership.Models.ViewModels.Veiculo;
using CarDealership.Models.ViewModels.Venda;

namespace CarDealership.Services
{
    public interface IVendaService
    {
        Task<List<VendaViewModel>> ListarVendas();

        Task<VendaViewModel> ListarPorId(int id);

        Task<CriarVendaViewModel> Criar(CriarVendaViewModel venda);
        Task<VendaViewModel> Editar(VendaViewModel venda);
        Task Excluir(int id);
        Task<CriarVendaViewModel> ObterVendaViewModel();
        Task<VendaViewModel> ObterEditViewModel(int id);
    }
}
