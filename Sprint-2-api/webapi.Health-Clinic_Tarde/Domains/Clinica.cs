using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Health_Clinic_Tarde.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]

        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR (100)")]
        [Required(ErrorMessage = "Endereço obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome fantasia é obrigatório !")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é obrigatório !")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A Razão Social é obrigatório !")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de abertura é obrigatório!")]
        public TimeOnly? HorarioAbertura { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de fechamento é obrigatório!")]
        public TimeOnly? HorarioFechamento { get; set; }
    }
}
