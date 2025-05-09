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
    /// <summary>
    /// Controller para gerenciar os veiculos.
    /// </summary>
    [Authorize(Roles = "gerente")]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }


        /// <summary>
        /// Mostra a pagina de listagem de Veiculos.
        /// </summary>
        // GET /Veiculo
        [HttpGet]
        public async Task<ActionResult<List<VeiculoViewModel>>> Index()
        {
            var result = await _veiculoService.ListarVeiculos();
            return View(result);
        }

        /// <summary>
        /// Mostra a pagina de criacao de veiculo.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<VeiculoViewModel>> Criar()
        {
            var result = await _veiculoService.ObterVeiculoViewModel();
            return View(result);
        }

        /// <summary>
        /// Recebe a requisicao POST com os dados de criacao do veiculo
        /// </summary>
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

        /// <summary>
        /// Mostra a pagina de edicao de veiculo.
        /// </summary>
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

        /// <summary>
        /// Recebe a requisicao POST com os dados de Edicao do veiculo
        /// </summary>
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

        /// <summary>
        /// Recebe a requisicao POST com o id veiculo para realizar a exclusao logica
        /// </summary>
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
