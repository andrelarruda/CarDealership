using CarDealership.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CarDealership.Models;
using CarDealership.Models.ViewModels.Fabricante;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarDealership.Models.ViewModels.Veiculo
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "O Modelo deve ter no máximo 100 caracteres.")]
        public string Modelo { get; set; }

        [DisplayName("Ano de fabricação")]
        public int AnoFabricacao { get; set; }

        [DisplayName("Preço")]
        [Range(0.00, double.MaxValue, ErrorMessage = "O {0} deve ser positivo.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O fabricante é obrigatório.")]
        [DisplayName("Fabricante")]
        public int FabricanteId { get; set; }

        [ValidateNever]
        public FabricanteViewModel Fabricante { get; set; }

        [DisplayName("Tipo do veículo")]
        [Required(ErrorMessage = "Obrigatorio informar o tipo do veiculo")]
        public ETipoVeiculo TipoVeiculo { get; set; }

        [DisplayName("Descrição")]
        public string? Descricao { get; set; }

        [ValidateNever]
        public List<FabricanteViewModel> OpcoesFabricantes { get; set; }
    }
}
