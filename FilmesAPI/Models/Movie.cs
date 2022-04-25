using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo Título é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "No máximo 30 caracteres")]
        public string Gender { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }
    }
}
