using AutoMapper;
using CarDealership.Models.ViewModels.Fabricante;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Veiculo;
using CarDealership.Repositories;

namespace CarDealership.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IFabricanteService _fabricanteService;

        public VeiculoService(IVeiculoRepository veiculoRepository, IMapper mapper, IFabricanteService fabricanteService)
        {
            _repository = veiculoRepository;
            _mapper = mapper;
            _fabricanteService = fabricanteService;
        }

        public async Task<VeiculoViewModel> Criar(VeiculoViewModel veiculo)
        {
            var fabricanteCriado = await _repository.Create(_mapper.Map<Veiculo>(veiculo));
            return veiculo;
        }

        public async Task<VeiculoViewModel> Editar(VeiculoViewModel veiculo)
        {
            await _repository.GetByIdAsync(veiculo.Id);
            await _repository.Update(_mapper.Map<Veiculo>(veiculo));
            return veiculo;
        }

        public async Task Excluir(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<VeiculoViewModel> ListarPorId(int id)
        {
            Veiculo veiculo = await _repository.GetByIdAsync(id);
            VeiculoViewModel result = _mapper.Map<VeiculoViewModel>(veiculo);
            result.OpcoesFabricantes = await _fabricanteService.ListarFabricantes();
            return result;
        }

        public async Task<List<VeiculoViewModel>> ListarVeiculos()
        {
            List<Veiculo> listaVeiculos = await _repository.GetAllAsync();
            return listaVeiculos.Select(f => _mapper.Map<VeiculoViewModel>(f)).ToList();
        }

        public async Task<VeiculoViewModel> ObterVeiculoViewModel()
        {
            VeiculoViewModel result = new VeiculoViewModel();
            result.OpcoesFabricantes = await _fabricanteService.ListarFabricantes();
            return result;
        }
    }
}
