using CarDealership.Data;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Repositories
{
    public class FabricanteRepository : IFabricanteRepository
    {
        private readonly CarDealershipContext _context;

        public FabricanteRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public async Task<Fabricante> Create(Fabricante fabricante)
        {
            try
            {
                await _context.Fabricantes.AddAsync(fabricante);
                await _context.SaveChangesAsync();
                return fabricante;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro no banco de dados: {ex.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var fabricante = await _context.Fabricantes.FirstOrDefaultAsync(p => p.Id == id);
                if (fabricante == null)
                {
                    throw new KeyNotFoundException("Fabricante nao encontrado.");
                }
                fabricante.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Algo deu errado ao deletar fabricante. {ex.Message}");
            }
        }

        public async Task<List<Fabricante>> GetAllAsync()
        {
            return await _context.Fabricantes
                .Where(f => !f.IsDeleted)
                .ToListAsync();
        }

        public async Task<Fabricante> GetByIdAsync(int id)
        {
            try
            {
                var fabricante = await _context.Fabricantes.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                if (fabricante == null)
                {
                    throw new KeyNotFoundException("Fabricante nao encontrado.");
                }
                return fabricante;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Fabricante> Update(Fabricante fabricante)
        {
            try
            {
                _context.Update(fabricante);
                await _context.SaveChangesAsync();
                return fabricante;
            }
            catch (Exception ex)
            {
                throw new Exception($"Algo deu errado ao atualizar o fabricante: {ex.Message}");
            }
        }

        public async Task<bool> VerificaSeFabricanteJaExiste(string nomeFabricante)
        {
            return await _context.Fabricantes.AnyAsync(f => f.Nome.ToLower() == nomeFabricante.ToLower());
        }
    }
}
