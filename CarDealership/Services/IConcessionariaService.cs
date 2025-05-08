using CarDealership.Models.ViewModels.Concessionaria;
using CarDealership.Models.ViewModels.Veiculo;

namespace CarDealership.Services
{
    public interface IConcessionariaService
    {
        Task<List<ConcessionariaViewModel>> ListarConcessionarias();

        Task<ConcessionariaViewModel> ListarPorId(int id);

        Task<ConcessionariaViewModel> Criar(ConcessionariaViewModel veiculo);
        Task<ConcessionariaViewModel> Editar(ConcessionariaViewModel veiculo);
        Task Excluir(int id);
    }
}
