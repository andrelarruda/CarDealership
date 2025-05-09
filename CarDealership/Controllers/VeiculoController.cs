using CarDealership.Models;
using CarDealership.Models.Enum;
using CarDealership.Models.ViewModels.Fabricante;
using CarDealership.Models.ViewModels.Veiculo;
using CarDealership.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarDealership.Controllers
{
    [Authorize(Roles = "gerente")]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }


        // GET /Veiculo
        [HttpGet]
        public async Task<ActionResult<List<VeiculoViewModel>>> Index()
        {
            var result = await _veiculoService.ListarVeiculos();
            return View(result);
        }

        [HttpGet]
        public async Task<ActionResult<VeiculoViewModel>> Criar()
        {
            var result = await _veiculoService.ObterVeiculoViewModel();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(VeiculoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VeiculoViewModel veiculo = await _veiculoService.Criar(model);

                    TempData["Sucesso"] = $"Veiculo {veiculo.Modelo} criado com sucesso!";
                    return RedirectToAction("Index", "Veiculo");
                }
                model = await _veiculoService.ObterVeiculoViewModel();
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult<VeiculoViewModel>> Editar(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Um id deve ser informado.");
                }

                VeiculoViewModel veiculo = await _veiculoService.ListarPorId(id);
                return View(veiculo);
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
        public async Task<IActionResult> Editar(VeiculoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VeiculoViewModel veiculo = await _veiculoService.Editar(model);

                    TempData["Sucesso"] = $"Veiculo {veiculo.Modelo} atualizado com sucesso!";
                    return RedirectToAction("Index", "Veiculo");
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
                await _veiculoService.Excluir(id);
                TempData["Sucesso"] = "Veiculo excluido com sucesso!";
                return RedirectToAction("Index", "Veiculo");
            }
            catch (KeyNotFoundException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Veiculo");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Veiculo");
            }
        }
    }
}
