﻿using System.ComponentModel.DataAnnotations;

namespace Filmes.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo de nome é obrigatorio")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Sessao> sessoes { get; set; }
    }
}
