using AutoMapper;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Fabricante;

namespace CarDealership.Settings
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {
            CreateMap<Fabricante, FabricanteViewModel>().ReverseMap();
            CreateMap<Fabricante, EditarFabricanteViewModel>().ReverseMap();
        }
    }
}
