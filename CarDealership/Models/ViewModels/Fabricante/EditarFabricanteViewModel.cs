using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Fabricante
{
    public class EditarFabricanteViewModel : IValidatableObject
    {
        [Required]

        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [Required(ErrorMessage = "É obrigatório informar o {0}")]
        [DisplayName("Nome da fabricante")]
        public string Nome { get; set; }

        [MaxLength(50, ErrorMessage = "O {0} deve ter no máximo 50 caracteres.")]
        [DisplayName("País de Origem")]
        public string PaisOrigem { get; set; }

        [DisplayName("Ano de fundação")]
        public int AnoFundacao { get; set; }

        [MaxLength(255, ErrorMessage = "O Website deve ter no máximo 255 caracteres.")]
        [DisplayName("Site")]
        public string Website { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (AnoFundacao >= DateTime.Now.Year)
            {
                yield return new ValidationResult($"Ano invalido. Digite um ano no passado.", new[] { nameof(AnoFundacao) });
            }
            else if (AnoFundacao < 1)
            {
                yield return new ValidationResult($"Ano invalido. Digite um valor superior a 1.", new[] { nameof(AnoFundacao) });
            }
        }
    }
}
