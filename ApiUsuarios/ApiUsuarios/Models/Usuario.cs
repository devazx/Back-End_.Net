using Microsoft.AspNetCore.Identity;

namespace ApiUsuarios.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }
        public Usuario(): base() { }
    }
}
