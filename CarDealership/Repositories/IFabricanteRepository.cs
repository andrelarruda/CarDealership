using CarDealership.Models;

namespace CarDealership.Repositories
{
    public interface IFabricanteRepository
    {
        Task<List<Fabricante>> GetAllAsync();
        Task<Fabricante> GetByIdAsync(int id);
        Task<Fabricante> Create(Fabricante fabricante);
        Task<Fabricante> Update(Fabricante fabricante);
        Task Delete(Fabricante fabricante);
        Task<bool> VerificaSeFabricanteJaExiste(string nomeFabricante);
    }
}
