using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
    }
}
