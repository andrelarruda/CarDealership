﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Cliente
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "O CPF deve ter no maximo 11 caracteres.")]
        [DisplayName("CPF do cliente")]
        public string CPF { get; set; }

        [MaxLength(15, ErrorMessage = "O Telefone deve ter no máximo 15 caracteres.")]
        [DisplayName("Telefone do cliente")]
        public string Telefone { get; set; }
    }
}
