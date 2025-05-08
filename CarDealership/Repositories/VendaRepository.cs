using CarDealership.Data;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly CarDealershipContext _context;

        public VendaRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public async Task<Venda> Create(Venda entity)
        {
            try
            {
                entity.Cliente = null;
                await _context.Vendas.AddAsync(entity);
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
                var entity = await _context.Vendas.FirstOrDefaultAsync(p => p.Id == id);
                if (entity == null)
                {
                    throw new KeyNotFoundException("Venda nao encontrada.");
                }
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Algo deu errado ao deletar Venda. {ex.Message}");
            }
        }

        public async Task<List<Venda>> GetAllAsync()
        {
            return await _context.Vendas
                .Include(v => v.Concessionaria)
                .Include(v => v.Cliente)
                .Include(v => v.Veiculo).ThenInclude(v => v.Fabricante)
                .Where(f => !f.IsDeleted)
                .ToListAsync();
        }

        public async Task<Venda> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Vendas
                    .Include(v => v.Concessionaria)
                    .Include(v => v.Cliente)
                    .Include(v => v.Veiculo).ThenInclude(v => v.Fabricante)
                    .AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
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

        public async Task<Venda> Update(Venda entity)
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
