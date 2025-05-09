using CarDealership.Models;
using CarDealership.Models.ViewModels.Fabricante;
using CarDealership.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Controllers
{
    [Authorize(Roles = "administrador")]
    public class FabricanteController : Controller
    {
        private readonly IFabricanteService _fabricanteService;
        public FabricanteController(IFabricanteService fabricanteService)
        {
            _fabricanteService = fabricanteService;
        }
        /// <summary>
        /// Retorna a pagina de listagem de Fabricantes.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<FabricanteViewModel>>> Index()
        {
            var result = await _fabricanteService.ListarFabricantes();
            return View(result);
        }

        /// <summary>
        /// Retorna a pagina de Criacao de Fabricante.
        /// </summary>
        [HttpGet]
        public IActionResult Criar()
        {
            return View(new FabricanteViewModel());
        }

        /// <summary>
        /// Recebe a requisicao POST com as informacoes de Criacao da Fabricante.
        /// </summary>
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
        /// <summary>
        /// Retorna a pagina de Edicao de Fabricante.
        /// </summary>
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

        /// <summary>
        /// Recebe a requisicao POST com as informacoes de Edicao da Fabricante.
        /// </summary>
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

        /// <summary>
        /// Recebe a requisicao POST com o id, para Deletar logicamente a Fabricante.
        /// Retorna a pagina de Criacao de Fabricante.
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
                await _fabricanteService.Excluir(id);
                TempData["Sucesso"] = "Fabricante excluido com sucesso!";
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
