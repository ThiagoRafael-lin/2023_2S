using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic_Tarde.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]

        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Prontuario obrigatório")]
        public string? Prontuario { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Horario obrigatório !")]
        public DateTime DataConsulta { get; set; }


        //ref.tabela TipoUsuario = FK

        [Required(ErrorMessage = "O tipo do usuario é obrigatório !")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }

        //ref.tabela Medico = FK

        [Required(ErrorMessage = "O nome do Medico é obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        //ref.tabela paciente = FK

        [Required(ErrorMessage = "O nome do Paciente é obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }
    }
}

