using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class Concessionaria : BaseEntity
    {
        // [Index(IsUnique=true)] // TODO: testar se funciona qnd instalar o EF
        [Required]
        [MaxLength(100,ErrorMessage = "O nome deve ter no maximo 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(255, ErrorMessage = "O endereço deve ter no máximo 255 caracteres.")]
        public string Endereco { get; set; }

        [MaxLength(50, ErrorMessage = "A Cidade deve ter no máximo 50 caracteres.")]
        public string Cidade { get; set; }

        [MaxLength(50, ErrorMessage = "O Estado deve ter no máximo 50 caracteres.")]
        public string Estado { get; set; }

        [MaxLength(10, ErrorMessage = "O CEP deve ter no máximo 10 caracteres.")]
        public string CEP { get; set; }

        [MaxLength(15, ErrorMessage = "O Telefone deve ter no máximo 15 caracteres.")]
        public string Telefone { get; set; }

        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        public int CapacidadeMaximaVeiculos { get; set; }

        public List<Venda> Vendas { get; set; }

    }
}
