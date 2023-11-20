using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic_Tarde.Domains
{
    [Table(nameof(Especialidade))]

    public class Especialidade
    {
        [Key]

        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Especialidade obrigatório")]
        public string? NomeProfissao { get; set; }
    }
}
