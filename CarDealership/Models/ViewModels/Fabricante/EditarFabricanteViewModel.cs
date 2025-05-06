using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Fabricante
{
    public class EditarFabricanteViewModel
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(50, ErrorMessage = "O Pais de origem deve ter no máximo 50 caracteres.")]
        public string PaisOrigem { get; set; }

        public int AnoFundacao { get; set; }

        [MaxLength(255, ErrorMessage = "O Website deve ter no máximo 255 caracteres.")]
        [DisplayName("Site")]
        public string Website { get; set; }
    }
}
