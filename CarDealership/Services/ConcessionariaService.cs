using AutoMapper;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Concessionaria;
using CarDealership.Repositories;

namespace CarDealership.Services
{
    public class ConcessionariaService : IConcessionariaService
    {
        private readonly IConcessionariaRepository _repository;
        private readonly IMapper _mapper;

        public ConcessionariaService(IConcessionariaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ConcessionariaViewModel> Criar(ConcessionariaViewModel viewModel)
        {
            var concessionariaCriada = await _repository.Create(_mapper.Map<Concessionaria>(viewModel));
            return viewModel;
        }

        public async Task<ConcessionariaViewModel> Editar(ConcessionariaViewModel viewModel)
        {
            await _repository.GetByIdAsync(viewModel.Id);
            await _repository.Update(_mapper.Map<Concessionaria>(viewModel));
            return viewModel;
        }

        public async Task Excluir(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<ConcessionariaViewModel>> ListarConcessionarias()
        {
            List<Concessionaria> listaEntidades = await _repository.GetAllAsync();
            return listaEntidades.Select(f => _mapper.Map<ConcessionariaViewModel>(f)).ToList();
        }

        public async Task<ConcessionariaViewModel> ListarPorId(int id)
        {
            Concessionaria entity = await _repository.GetByIdAsync(id);
            ConcessionariaViewModel result = _mapper.Map<ConcessionariaViewModel>(entity);
            return result;
        }
    }
}
