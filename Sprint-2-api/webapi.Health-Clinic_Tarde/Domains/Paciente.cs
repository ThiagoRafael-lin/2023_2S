using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic_Tarde.Domains
{
    [Table(nameof(Paciente))]


    public class Paciente
    {

        [Key]

        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        //ref.tabela Usuario = FK

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "CPF é obrigatório !")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(3)")]
        [Required(ErrorMessage = "Idade obrigatória!")]
        public string? Idade { get; set; }

        //ref.tabela Usuario = FK

        [Required(ErrorMessage = "Nome do Usuario obrigatório !")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
