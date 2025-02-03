using Filmes.Data;
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

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        //private static List<Filme> filmes = new List<Filme>();

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
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
