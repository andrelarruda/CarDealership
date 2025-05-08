using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Repositories
{
    public interface IClienteRepository : ICrudRepository<Cliente>
    {
        Task<Cliente> GetByCPF(string cpf);
    }
}
