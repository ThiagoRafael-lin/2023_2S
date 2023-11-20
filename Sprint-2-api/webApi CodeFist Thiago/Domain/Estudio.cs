
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi_CodeFist_Thiago.Domain
{
    [Table("Estudio")]

    public class Estudio
    {
        [Key]
        public Guid IdEstudios { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string? Nome { get; set; }

        //ref.Lista de jogos
        public List<Jogo>? Jogos { get; set; }
    }
}
