using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic_Tarde.Domains
{
    [Table(nameof(Comentario))]

    public class Comentario
    {
        [Key]

        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Descrição obrigatório")]
        public string? Descricao { get; set; }

        //ref.tabela Usuario = FK

        [Required(ErrorMessage = "O Usuario é obrigatório !")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
