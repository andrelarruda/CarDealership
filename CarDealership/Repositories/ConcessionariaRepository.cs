using CarDealership.Data;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Repositories
{
    public class ConcessionariaRepository : IConcessionariaRepository
    {
        private readonly CarDealershipContext _context;

        public ConcessionariaRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public async Task<Concessionaria> Create(Concessionaria entity)
        {
            try
            {
                await _context.Concessionarias.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
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
                var entity = await _context.Concessionarias.FirstOrDefaultAsync(p => p.Id == id);
                if (entity == null)
                {
                    throw new KeyNotFoundException("Concessionaria nao encontrado.");
                }
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Algo deu errado ao deletar concessionaria. {ex.Message}");
            }
        }

        public async Task<List<Concessionaria>> GetAllAsync()
        {
            return await _context.Concessionarias
                .Where(f => !f.IsDeleted)
                .ToListAsync();
        }

        public async Task<Concessionaria> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Concessionarias.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                if (entity == null)
                {
                    throw new KeyNotFoundException("Veiculo nao encontrado.");
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Concessionaria> Update(Concessionaria entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Algo deu errado ao atualizar o fabricante: {ex.Message}");
            }
        }
    }
}
