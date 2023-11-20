using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic_Tarde.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]

    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();


        [Column(TypeName = " CHAR(11) ")]
        [Required(ErrorMessage = "CRM obrigatório !")]
        public string? CRM { get; set; }

        //ref.tabela Especialidade = FK

        [Required(ErrorMessage = "A Especialidade é obrigatória !")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]

        public Especialidade? Especialidade { get; set; }

        //ref.tabela Usuario = FK

        [Required(ErrorMessage = "Nome do Usuario obrigatório !")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //ref.tabela Clinica = FK

        [Required(ErrorMessage = "Clinica é Obrigatorio")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
