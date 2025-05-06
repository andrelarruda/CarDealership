using CarDealership.Models;
using CarDealership.Models.ViewModels.Fabricante;
using CarDealership.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    public class FabricanteController : Controller
    {
        private readonly IFabricanteService _fabricanteService;
        public FabricanteController(IFabricanteService fabricanteService)
        {
            _fabricanteService = fabricanteService;
        }
        // GET /Fabricante/
        [HttpGet]
        public async Task<ActionResult<List<FabricanteViewModel>>> Index()
        {
            //var result2 = await _fabricanteService.ListarFabricantes();
            List<FabricanteViewModel> result = new List<FabricanteViewModel>()
            {
                new FabricanteViewModel()
                {
                    Id = 1,
                    Nome = "Volkswagen",
                    AnoFundacao = 1967,
                    PaisOrigem = "Alemanha",
                    Website = "https://www.vw.com.br/",
                },
                new FabricanteViewModel()
                {
                    Id = 2,
                    Nome = "Fiat",
                    AnoFundacao = 1988,
                    PaisOrigem = "Italia",
                    Website = "https://www.fiat.com.br/",
                },
                new FabricanteViewModel()
                {
                    Id = 3,
                    Nome = "Chevrolet",
                    AnoFundacao = 1956,
                    PaisOrigem = "Estados Unidos da América",
                    Website = "https://www.chevrolet.com.br/",
                },
                new FabricanteViewModel()
                {
                    Id = 4,
                    Nome = "Ford",
                    AnoFundacao = 1935,
                    PaisOrigem = "Estados Unidos da América",
                    Website = "https://www.ford.com.br/",
                },
            };
            return View(result);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            CriarEditarFabricanteViewModel<FabricanteViewModel> viewModel = new CriarEditarFabricanteViewModel<FabricanteViewModel>{ Modelo = new FabricanteViewModel() };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(FabricanteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FabricanteViewModel fabricante = await _fabricanteService.Criar(model);

                    TempData["Sucesso"] = $"Fabricante {fabricante.Nome} criado com sucesso!";
                    return RedirectToAction("Index", "Fabricante");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult<EditarFabricanteViewModel>> Editar(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Um id deve ser informado.");
                }
                EditarFabricanteViewModel fabricante = await _fabricanteService.ListarPorId(id);
                return View(fabricante);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
