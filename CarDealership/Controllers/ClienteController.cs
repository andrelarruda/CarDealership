using CarDealership.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> ConsultarClientePorCPF(string cpf)
        {
            return await _service.ConsultarPorCPF(cpf);
        }
    }
}
