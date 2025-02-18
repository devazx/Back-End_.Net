using ApiUsuarios.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Data
{
    public class UsuarioDbContext : IdentityDbContext<IdentityUser>
    {
        public UsuarioDbContext
            (DbContextOptions<UsuarioDbContext> opts) : base(opts) { }
        public DbSet<Usuario> usuario { get; set; }
    }
}
