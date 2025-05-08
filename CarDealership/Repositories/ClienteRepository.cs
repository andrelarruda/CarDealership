using CarDealership.Data;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CarDealershipContext _context;

        public ClienteRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public Task<Cliente> Create(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Where(f => !f.IsDeleted)
                .ToListAsync();
        }

        public Task<Cliente> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Update(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
