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
    public class UsuarioController : ControllerBase
    {
        public UsuarioService _usuarioService;
        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost("Cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.CadastraUsuario(dto);

            return Ok("Usuario Cadasrtado!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.Login(dto);
            return Ok(token);
        }
    }
}
