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
            var result = await _fabricanteService.ListarFabricantes();
            return View(result);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View(new FabricanteViewModel());
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

        [HttpPost]
        public async Task<IActionResult> Editar(EditarFabricanteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EditarFabricanteViewModel fabricante = await _fabricanteService.Editar(model);

                    TempData["Sucesso"] = $"Fabricante {fabricante.Nome} atualizado com sucesso!";
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

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Um id deve ser informado.");
                }
                await _fabricanteService.Excluir(id);
                TempData["Sucesso"] = "Usuario excluido com sucesso!";
                return RedirectToAction("Index");
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
