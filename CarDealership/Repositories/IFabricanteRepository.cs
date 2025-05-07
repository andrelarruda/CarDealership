using CarDealership.Models;

namespace CarDealership.Repositories
{
    public interface IFabricanteRepository : ICrudRepository<Fabricante>
    {
        Task<bool> VerificaSeFabricanteJaExiste(string nomeFabricante);
    }
}
