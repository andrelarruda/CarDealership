using CarDealership.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace CarDealership.Models
{
    public class Usuario : IdentityUser
    {
        public NivelAcesso NivelAcesso { get; set; }
    }
}
