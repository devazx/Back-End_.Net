using ApiUsuarios.Data.Dtos;
using ApiUsuarios.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : Controller
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public UsuarioController(IMapper mapper, UserManager<Usuario> userManager = null)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (resultado.Succeeded) return Ok("Usuario Cadasrtado!");

            throw new ApplicationException("Falha ao cadastrar usuario!");
        }
    }
}
