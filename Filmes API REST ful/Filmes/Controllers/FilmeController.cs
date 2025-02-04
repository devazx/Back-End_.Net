using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos;
using Filmes.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorID), 
                new  { id = filme.Id }, filme);

        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery] int take = 50)
        {
            return _context.filmes.Skip(skip).Take(take);

        }
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorID(int id)
        {
            var filme =  _context.filmes.FirstOrDefault(filme => filme.Id.Equals(id));
            if(filme == null) return NotFound();
            return Ok(filme);

        }
    }
}
