using CarDealership.Data;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly CarDealershipContext _context;

        public VeiculoRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public async Task<Veiculo> Create(Veiculo veiculo)
        {
            try
            {
                await _context.Veiculos.AddAsync(veiculo);
                await _context.SaveChangesAsync();
                return veiculo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro no banco de dados: {ex.Message}");
            }
        }

        public async Task Delete(Veiculo veiculo)
        {
            try
            {
                //_context.Veiculos.Remove(veiculo);
                veiculo.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Algo deu errado ao deletar fabricante. {ex.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var veiculo = await _context.Veiculos.FirstOrDefaultAsync(p => p.Id == id);
                if (veiculo == null)
                {
                    throw new KeyNotFoundException("Veiculo nao encontrado.");
                }
                veiculo.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Algo deu errado ao deletar veiculo. {ex.Message}");
            }
        }

        public async Task<List<Veiculo>> GetAllAsync()
        {
            return await _context.Veiculos
                .Include(v => v.Fabricante)
                .Where(f => !f.IsDeleted)
                .ToListAsync();
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            try
            {
                var veiculo = await _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                if (veiculo == null)
                {
                    throw new KeyNotFoundException("Veiculo nao encontrado.");
                }
                return veiculo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Veiculo> Update(Veiculo veiculo)
        {
            try
            {
                _context.Update(veiculo);
                await _context.SaveChangesAsync();
                return veiculo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Algo deu errado ao atualizar o fabricante: {ex.Message}");
            }
        }

        public async Task<bool> VerificaSeVeiculoJaExiste(string modeloVeiculo)
        {
            return await _context.Fabricantes.AnyAsync(f => f.Nome.ToLower() == modeloVeiculo.ToLower());
        }
    }
}
