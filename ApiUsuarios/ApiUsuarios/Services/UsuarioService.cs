using ApiUsuarios.Data.Dtos;
using ApiUsuarios.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiUsuarios.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper,
            SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        
        internal async Task CadastraAsync(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded) throw new ApplicationException("Falha ao cadastrar usuario!");
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!result.Succeeded) throw new ApplicationException("Usuário não autenticado");

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName.Equals(dto.Username.ToUpper()));
            
            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}
