using AutoMapper;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Concessionaria;
using CarDealership.Models.ViewModels.Veiculo;
using CarDealership.Models.ViewModels.Cliente;
using CarDealership.Models.ViewModels.Venda;
using CarDealership.Repositories;

namespace CarDealership.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConcessionariaService _concessionariaService;
        private readonly IVeiculoService _veiculoService;
        private readonly IClienteService _clienteService;
        private readonly ILogger _logger;

        public VendaService(IVendaRepository repository, IMapper mapper, IConcessionariaService concessionariaService, IVeiculoService veiculoService, IClienteService clienteService, ILogger<VendaService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _concessionariaService = concessionariaService;
            _veiculoService = veiculoService;
            _clienteService = clienteService;
            _logger = logger;
        }

        public async Task<CriarVendaViewModel> Criar(CriarVendaViewModel viewModel)
        {
            try
            {
                if (viewModel.Cliente.Id.HasValue && viewModel.Cliente.Id.Value != 0)
                {
                    viewModel.ClienteId = viewModel.Cliente.Id.Value;
                }
                else
                {
                    Cliente clienteCriado = await _clienteService.Criar(viewModel.Cliente);
                    viewModel.ClienteId = clienteCriado.Id;
                }
                viewModel.Cliente = null;
                var vendaCriada = await _repository.Create(_mapper.Map<Venda>(viewModel));
                _logger.Log(LogLevel.Information, "Venda criada com sucesso.");
            }
            catch (Exception ex) {
                _logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
            return viewModel;
        }

        public async Task<VendaViewModel> Editar(VendaViewModel viewModel)
        {
            await _repository.GetByIdAsync(viewModel.Id);
            await _repository.Update(_mapper.Map<Venda>(viewModel));
            return viewModel;
        }

        public async Task Excluir(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<VendaViewModel> ListarPorId(int id)
        {
            Venda entity = await _repository.GetByIdAsync(id);
            VendaViewModel result = _mapper.Map<VendaViewModel>(entity);
            return result;
        }

        public async Task<List<VendaViewModel>> ListarVendas()
        {
            List<Venda> listaEntidades = await _repository.GetAllAsync();
            return listaEntidades.Select(f => _mapper.Map<VendaViewModel>(f)).ToList();
        }

        public async Task<CriarVendaViewModel> ObterVendaViewModel()
        {
            CriarVendaViewModel result = new CriarVendaViewModel();
            result.OpcoesConcessionarias = await _concessionariaService.ListarConcessionarias();
            result.OpcoesVeiculos = await _veiculoService.ListarVeiculos();
            result.OpcoesClientes = await _clienteService.ListarClientes();
            result.ProtocoloVenda = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
            return result;
        }
    }
}


