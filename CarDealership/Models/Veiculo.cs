using CarDealership.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class Veiculo : BaseEntity
    {
        [MaxLength(100, ErrorMessage = "O Modelo deve ter no máximo 100 caracteres.")]
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public decimal Preco { get; set; }
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }
        public ETipoVeiculo TipoVeiculo { get; set; }
        public string? Descricao { get; set; }
    }
}
