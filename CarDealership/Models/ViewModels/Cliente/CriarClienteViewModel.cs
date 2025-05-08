using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Cliente
{
    public class CriarClienteViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maximo 100 caracteres.")]
        [DisplayName("Nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [MaxLength(11, ErrorMessage = "O CPF deve ter no maximo 11 caracteres.")]
        [DisplayName("CPF do cliente")]
        public string CPF { get; set; }

        [MaxLength(15, ErrorMessage = "O {0} deve ter no máximo 15 caracteres.")]
        [DisplayName("Telefone do cliente")]
        public string Telefone { get; set; }
    }
}
