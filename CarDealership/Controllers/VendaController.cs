using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;
using CarDealership.Services;
using CarDealership.Models.ViewModels.Concessionaria;
using CarDealership.Models.ViewModels.Venda;
using Microsoft.AspNetCore.Authorization;

namespace CarDealership.Controllers
{
    [Authorize(Roles = "vendedor")]
    public class VendaController : Controller
    {
        private readonly CarDealershipContext _context;
        private readonly IVendaService _service;

        public VendaController(IVendaService service)
        {
            _service = service;
        }

        // GET: Venda
        public async Task<ActionResult<IEnumerable<VendaViewModel>>> Index()
        {
            var result = await _service.ListarVendas();
            return View(result);
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _service.ListarPorId(id.Value);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Venda/Create
        public async Task<ActionResult<CriarVendaViewModel>> Create()
        {
            var result = await _service.ObterVendaViewModel();
            return View(result);
        }

        // POST: Venda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriarVendaViewModel venda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entidadeCriada = await _service.Criar(venda);
                    TempData["Sucesso"] = $"Venda criada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                venda = await _service.ObterVendaViewModel();
                return View(venda);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao criar venda!";
                venda = await _service.ObterVendaViewModel();
                return View(venda);
            }
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VendaViewModel venda = await _service.ObterEditViewModel(id.Value);
            if (venda == null)
            {
                return NotFound();
            }
            return View(venda);
        }

        // POST: Venda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VeiculoId,ConcessionariaId,ClienteId,DataVenda,PrecoVenda,ProtocoloVenda,Id,CreatedAt,IsDeleted")] VendaViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    VendaViewModel venda = await _service.Editar(model);

                    TempData["Sucesso"] = $"Venda atualizada com sucesso!";
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CPF", venda.ClienteId);
            //ViewData["ConcessionariaId"] = new SelectList(_context.Concessionarias, "Id", "Nome", venda.ConcessionariaId);
            //ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Id", venda.VeiculoId);
            model = await _service.ObterEditViewModel(id);
            return View(model);
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
                await _service.Excluir(id);
                TempData["Sucesso"] = "Venda excluida com sucesso!";
                return RedirectToAction("Index", "Venda");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Venda");
            }
        }
    }
}
