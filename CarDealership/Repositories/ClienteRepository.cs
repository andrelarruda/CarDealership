﻿using CarDealership.Data;
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

        public async Task<Cliente> Create(Cliente entity)
        {
            try
            {
                await _context.Clientes.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro no banco de dados: {ex.Message}");
            }
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

        public async Task<Cliente> GetByCPF(string cpf)
        {
            return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.CPF == cpf);
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
