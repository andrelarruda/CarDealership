using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    public class Concessionaria : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
