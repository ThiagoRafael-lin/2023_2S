using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi_CodeFist_Thiago.Domain
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTiposUsuario { get; set; } = Guid.NewGuid();

        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo é obrigatório")]
        public Guid Titulo { get; set; }
    }
}
