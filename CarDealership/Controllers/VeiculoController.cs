using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    public class VeiculoController : Controller
    {
        // GET /Veiculo
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
