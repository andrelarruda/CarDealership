using CarDealership.Models.ViewModels.Fabricante;
namespace CarDealership.Services
{
    public interface IFabricanteService
    {
        Task<List<FabricanteViewModel>> ListarFabricantes();

        Task<EditarFabricanteViewModel> ListarPorId(int id);

        Task<FabricanteViewModel> Criar(FabricanteViewModel fabricante);
        Task<EditarFabricanteViewModel> Editar(EditarFabricanteViewModel fabricante);
        Task Excluir(int id);
    }
}
