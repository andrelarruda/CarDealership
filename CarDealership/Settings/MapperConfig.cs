using AutoMapper;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Concessionaria;
using CarDealership.Models.ViewModels.Fabricante;
using CarDealership.Models.ViewModels.Veiculo;

namespace CarDealership.Settings
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {
            CreateMap<Fabricante, FabricanteViewModel>().ReverseMap();
            CreateMap<Fabricante, EditarFabricanteViewModel>().ReverseMap();

            CreateMap<Veiculo, VeiculoViewModel>()
                //.ForMember(veiculoVM => veiculoVM.Fabricante, x => x.MapFrom(veiculo => veiculo.Fabricante))
                .ReverseMap();

            CreateMap<Concessionaria, ConcessionariaViewModel>()
                .ReverseMap();
        }
    }
}
