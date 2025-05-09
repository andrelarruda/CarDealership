using CarDealership.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Rota utilizada pela requisicao Ajax para consultar cliente por CPF
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> ConsultarClientePorCPF(string cpf)
        {
            return await _service.ConsultarPorCPF(cpf);
        }
    }
}
