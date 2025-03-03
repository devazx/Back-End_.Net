﻿using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos;
using Filmes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //private static List<Filme> filmes = new List<Filme>();
        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorID), 
                new  { id = filme.Id }, filme);

        }

        [HttpGet]
        public IEnumerable<ReadFilmeDto> RecuperaFilmes(
            [FromQuery]int skip = 0, 
            [FromQuery] int take = 50,
            [FromQuery] string? nomeCinema = null)
        {
            if (nomeCinema == null)
            {
                return _mapper.Map<List<ReadFilmeDto>>(_context.filmes.Skip(skip).Take(take).ToList());
            }
            return _mapper.Map<List<ReadFilmeDto>>(_context.filmes
                .Skip(skip).Take(take).Where(filme => filme.Sessoes
                .Any(sessao => sessao.Cinema.Nome == nomeCinema)).ToList());
                
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorID(int id)
        {
            var filme =  _context.filmes.FirstOrDefault(filme => filme.Id.Equals(id));
            if(filme == null) return NotFound();
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);

        }
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = _context.filmes.FirstOrDefault(
                filme => filme.Id == id);
            if(filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> path)
        {
            var filme = _context.filmes.FirstOrDefault(
                filme => filme.Id == id);
            if (filme == null) return NotFound();

            var filmeParaAtualiza = _mapper.Map<UpdateFilmeDto>(filme);

            path.ApplyTo(filmeParaAtualiza, ModelState);

            if(!TryValidateModel(filmeParaAtualiza)) return ValidationProblem(ModelState);

            _mapper.Map(filmeParaAtualiza, filme);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        { 
            var filme = _context.filmes.FirstOrDefault(
                filme => filme.Id == id);
            if (filme == null) return NotFound();
            _context.filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
