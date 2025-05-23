﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarDealership.Data;
using CarDealership.Models;
using CarDealership.Services;
using CarDealership.Models.ViewModels.Veiculo;
using CarDealership.Models.ViewModels.Concessionaria;
using Microsoft.AspNetCore.Authorization;

namespace CarDealership.Controllers
{
    [Authorize(Roles = "administrador")]
    public class ConcessionariaController : Controller
    {
        private readonly IConcessionariaService _service;

        public ConcessionariaController(IConcessionariaService concessionariaService)
        {
            _service = concessionariaService;
        }

        /// <summary>
        /// Mostra a pagina de listagem de Concessionarias.
        /// </summary>
        public async Task<ActionResult<List<ConcessionariaViewModel>>> Index()
        {
            var result = await _service.ListarConcessionarias();
            return View(result);
        }

        /// <summary>
        /// Retorna a pagina de detalhes da Concessionaria.
        /// </summary>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concessionaria = await _service.ListarPorId(id.Value);
            if (concessionaria == null)
            {
                return NotFound();
            }

            return View(concessionaria);
        }

        /// <summary>
        /// Mostra a pagina de Criacao de Concessionaria.
        /// </summary>
        public IActionResult Create()
        {
            return View(new ConcessionariaViewModel());
        }

        /// <summary>
        /// Recebe a requisicao POST com os dados para criacao de Concessionaria.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco,Cidade,Estado,CEP,Telefone,Email,CapacidadeMaximaVeiculos,Id,CreatedAt,IsDeleted")] ConcessionariaViewModel concessionaria)
        {
            if (ModelState.IsValid)
            {
                var entidadeCriada = await _service.Criar(concessionaria);
                TempData["Sucesso"] = $"Concessionaria {concessionaria.Nome} criada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(concessionaria);
        }

        /// <summary>
        /// Retorna a pagina de edicao de Concessionaria.
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConcessionariaViewModel concessionaria = await _service.ListarPorId(id.Value);
            if (concessionaria == null)
            {
                return NotFound();
            }
            return View(concessionaria);
        }

        /// <summary>
        /// Recebe a requisicao POST com os dados para Edicao de Concessionaria.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Endereco,Cidade,Estado,CEP,Telefone,Email,CapacidadeMaximaVeiculos,Id,CreatedAt,IsDeleted")] ConcessionariaViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ConcessionariaViewModel concessionaria = await _service.Editar(model);

                    TempData["Sucesso"] = $"Concessionaria {concessionaria.Nome} atualizada com sucesso!";
                    
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        /// <summary>
        /// Recebe a requisicao POST com o id para Deletar a Concessionaria.
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
                await _service.Excluir(id);
                TempData["Sucesso"] = "Concessionaria excluida com sucesso!";
                return RedirectToAction("Index", "Concessionaria");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Concessionaria");
            }
        }
    }
}
