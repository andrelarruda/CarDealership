using CarDealership.Models.ViewModels.Cliente;
using CarDealership.Models.ViewModels.Concessionaria;
using CarDealership.Models.ViewModels.Veiculo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CarDealership.Models.ViewModels.Fabricante;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarDealership.Models.ViewModels.Venda
{
    public class VendaViewModel : IValidatableObject
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

        [ValidateNever]
        public ConcessionariaViewModel Concessionaria { get; set; }

        //[Required(ErrorMessage = "É obrigatório selecionar o Cliente.")]
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        public ClienteViewModel Cliente { get; set; }

        [DisplayName("Data da venda")]
        public DateTime DataVenda { get; set; }

        [DisplayName("Preço da venda")]
        public decimal PrecoVenda { get; set; }

        [DisplayName("Protocolo da venda")]
        public string ProtocoloVenda { get; set; }

        [ValidateNever]
        public List<VeiculoViewModel> OpcoesVeiculos { get; set; }

        [ValidateNever]
        public List<ConcessionariaViewModel> OpcoesConcessionarias { get; set; }

        [ValidateNever]
        public List<ClienteViewModel> OpcoesClientes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (PrecoVenda > Veiculo.Preco)
            //{
            //    yield return new ValidationResult($"O preço da venda deve ser menor ou igual ao preço do veículo.", new[] { nameof(PrecoVenda) });
            //}

            if (ProtocoloVenda != null && ProtocoloVenda.Length > 20)
            {
                yield return new ValidationResult($"O protocolo da venda deve ter no maximo 20 caracteres.", new[] { nameof(ProtocoloVenda) });
            }
        }

    }
}
