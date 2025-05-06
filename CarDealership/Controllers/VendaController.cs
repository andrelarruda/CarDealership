using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    public class VendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
