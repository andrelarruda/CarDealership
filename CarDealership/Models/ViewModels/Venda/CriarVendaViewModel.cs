using CarDealership.Models.ViewModels.Cliente;
using CarDealership.Models.ViewModels.Concessionaria;
using CarDealership.Models.ViewModels.Veiculo;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Venda
{
    public class CriarVendaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar o Veículo.")]
        [DisplayName("Veiculo")]
        public int VeiculoId { get; set; }

        [ValidateNever]
        public VeiculoViewModel Veiculo { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar a Concessionária.")]
        [DisplayName("Concessionária")]
        public int ConcessionariaId { get; set; }

        //[Required(ErrorMessage = "É obrigatório selecionar o Cliente.")]
        [DisplayName("Cliente")]
        [ValidateNever]
        public int ClienteId { get; set; }

        public CriarClienteViewModel Cliente { get; set; }

        [DisplayName("Data da venda")]
        public DateTime DataVenda { get; set; } = DateTime.Now;

        [DisplayName("Preço da venda")]
        public decimal PrecoVenda { get; set; }

        [DisplayName("Protocolo da venda")]
        [StringLength(20)]
        public string ProtocoloVenda { get; set; }

        [ValidateNever]
        public List<VeiculoViewModel> OpcoesVeiculos { get; set; }

        [ValidateNever]
        public List<ConcessionariaViewModel> OpcoesConcessionarias { get; set; }

        [ValidateNever]
        public List<ClienteViewModel> OpcoesClientes { get; set; }
    }
}
