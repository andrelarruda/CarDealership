using CarDealership.Models.ViewModels.Fabricante;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class Fabricante : BaseEntity
    {
        //[Index(IsUnique=true)] // testar se funciona qnd instalar o EntityFramework
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(50, ErrorMessage = "O Pais de origem deve ter no máximo 50 caracteres.")]
        public string PaisOrigem { get; set; }

        public int AnoFundacao { get; set; }

        [MaxLength(255, ErrorMessage = "O Website deve ter no máximo 255 caracteres.")]
        public string Website { get; set; }

        public List<Veiculo> Veiculos { get; set; }
    }
}
