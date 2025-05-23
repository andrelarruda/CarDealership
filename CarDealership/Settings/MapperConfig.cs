﻿using AutoMapper;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Cliente;
using CarDealership.Models.ViewModels.Concessionaria;
using CarDealership.Models.ViewModels.Fabricante;
using CarDealership.Models.ViewModels.Veiculo;
using CarDealership.Models.ViewModels.Venda;

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

            CreateMap<Venda, VendaViewModel>()
                .ReverseMap();
            CreateMap<Venda, CriarVendaViewModel>()
                .ReverseMap();

            CreateMap<Cliente, ClienteViewModel>()
                .ReverseMap();
            CreateMap<Cliente, CriarClienteViewModel>()
                .ReverseMap();
        }
    }
}
