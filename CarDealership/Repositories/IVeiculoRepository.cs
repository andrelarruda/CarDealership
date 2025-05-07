using CarDealership.Models;

namespace CarDealership.Repositories
{
    public interface IVeiculoRepository : ICrudRepository<Veiculo>
    {
        Task<bool> VerificaSeVeiculoJaExiste(string nomeFabricante);
    }
}
