using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Concessionaria
{
    public class ConcessionariaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no maximo 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(255, ErrorMessage = "O endereço deve ter no máximo 255 caracteres.")]
        public string Endereco { get; set; }

        [MaxLength(50, ErrorMessage = "A Cidade deve ter no máximo 50 caracteres.")]
        public string Cidade { get; set; }

        [MaxLength(50, ErrorMessage = "O Estado deve ter no máximo 50 caracteres.")]
        public string Estado { get; set; }

        [MaxLength(10, ErrorMessage = "O CEP deve ter no máximo 10 caracteres.")]
        [RegularExpression("(^[0-9]{5})-?([0-9]{3}$)", ErrorMessage = "CEP fora do padrao.")]
        public string CEP { get; set; }

        [MaxLength(15, ErrorMessage = "O Telefone deve ter no máximo 15 caracteres.")]
        [RegularExpression("^\\([1-9]{2}\\) (?:[2-8]|9[0-9])[0-9]{3}\\-[0-9]{4}$", ErrorMessage = "Digite o telefone no padrão: (xx) xxxxx-xxxx")]
        public string Telefone { get; set; }

        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "Informe o {0} no formato: example@domain.com.")]
        public string Email { get; set; }

        [DisplayName("Capacidade máxima de veículos")]
        public int CapacidadeMaximaVeiculos { get; set; }

        //public List<Venda> Vendas { get; set; }
    }
}
