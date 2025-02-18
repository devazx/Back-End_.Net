﻿using ApiUsuarios.Data.Dtos;
using ApiUsuarios.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiUsuarios.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public CadastroService (UserManager<Usuario> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        
        internal async Task CadastraAsync(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded) throw new ApplicationException("Falha ao cadastrar usuario!");
        }
    }
}
