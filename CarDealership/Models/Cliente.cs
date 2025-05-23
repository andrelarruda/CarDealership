﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class Cliente : BaseEntity
    {
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "O CPF deve ter no maximo 11 caracteres.")]
        public string CPF { get; set; }

        [MaxLength(15, ErrorMessage = "O Telefone deve ter no máximo 15 caracteres.")]
        public string Telefone { get; set; }

        public List<Venda> Vendas { get; set; } // necessario?
    }
}
