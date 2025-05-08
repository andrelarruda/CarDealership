using CarDealership.Models.ViewModels.Veiculo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class Venda : BaseEntity
    {
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int ConcessionariaId { get; set; }
        public Concessionaria Concessionaria { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [DisplayName("Data da venda")]
        public DateTime DataVenda { get; set; }

        [DisplayName("Preço da venda")]
        public decimal PrecoVenda { get; set; }

        [MaxLength(20, ErrorMessage = "O Protocolo deve ter no máximo 20 caracteres.")]
        [DisplayName("Protocolo da venda")]
        public string ProtocoloVenda { get; set; }
    }
}
