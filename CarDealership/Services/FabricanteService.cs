using AutoMapper;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Fabricante;
using CarDealership.Repositories;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace CarDealership.Services
{
    public class FabricanteService : IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IMapper _mapper;
        public FabricanteService(IFabricanteRepository fabricanteRepository, IMapper mapper)
        {
            _fabricanteRepository = fabricanteRepository;
            _mapper = mapper;
        }

        public async Task<FabricanteViewModel> Criar(FabricanteViewModel model)
        {
            bool fabricanteJaExiste = await _fabricanteRepository.VerificaSeFabricanteJaExiste(model.Nome);
            if (fabricanteJaExiste)
            {
                throw new Exception("Fabricante ja cadastrado no sistema.");
            }

            var fabricanteCriado = await _fabricanteRepository.Create(new Fabricante
            {
                Nome = model.Nome,
                PaisOrigem = model.PaisOrigem,
                AnoFundacao = model.AnoFundacao,
                Website = model.Website,
            });
            return model;
        }

        public async Task<List<FabricanteViewModel>> ListarFabricantes()
        {
            List<Fabricante> listaFabricantes = await _fabricanteRepository.GetAllAsync();
            List<FabricanteViewModel> result = listaFabricantes.Select(f => _mapper.Map<FabricanteViewModel>(f)).ToList();
            //var result = from fabricante in listaFabricantes
            //             select new FabricanteViewModel
            //             {
            //                 Id = fabricante.Id,
            //                 Nome = fabricante.Nome,
            //                 AnoFundacao = fabricante.AnoFundacao,
            //                 PaisOrigem = fabricante.PaisOrigem,
            //                 Website = fabricante.Website,
            //             };

            return result.ToList();

        }

        public async Task<EditarFabricanteViewModel> ListarPorId(int id)
        {
            Fabricante fabricante = await _fabricanteRepository.GetByIdAsync(id);
            return _mapper.Map<EditarFabricanteViewModel>(fabricante);
        }
    }
}
