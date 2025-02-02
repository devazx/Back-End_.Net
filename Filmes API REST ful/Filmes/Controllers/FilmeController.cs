using Filmes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Duracao);

        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery] int take = 50)
        {
            return filmes.Skip(skip).Take(take);

        }
        [HttpGet("{id}")]
        public Filme? RecuperaFilmePorID(int id)
        {
            return filmes.FirstOrDefault(filme => filme.Id.Equals(id));
        }
    }
}
