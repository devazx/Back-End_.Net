using ApiUsuarios.Data.Dtos;
using ApiUsuarios.Models;
using ApiUsuarios.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : Controller
    {
        private CadastroService _cadastroService;
        public UsuarioController(CadastroService cadastroService)
        {
            cadastroService = _cadastroService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _cadastroService.CadastraAsync(dto);
            return Ok("Usuario Cadasrtado!");
        }
    }
}
