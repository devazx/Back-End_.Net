﻿using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O titulo do filme é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O genero do filme é obrigatorio")]
        [StringLength(50, ErrorMessage = "O tamanho do genero nao pode exceder 50 caracteres")]
        public string Genero { get; set; }
        [Required]
        [Range(70, 600, ErrorMessage = "A duracao tem que ser entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
