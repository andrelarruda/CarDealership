using CarDealership.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace CarDealership.Models
{
    public class Usuario : IdentityUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public NivelAcesso NivelAcesso { get; set; }
    }
}
