using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi_CodeFist_Thiago.Domain
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();


        [Column (TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogos obrigatório")]

        public String? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Descrição do Jogo")]

        public string Descricao { get; set; }
        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de Lançamento do jogo obrigatório!")]

        public DateTime DataLancamento { get; set; }


        [Column(TypeName = "decimal(4,2)")]
        [Required(ErrorMessage = "preço do jogo obrigatório!")]
        public decimal Preco { get; set; }

        //ref.tabela estúdio - FK

        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]

        public Estudio? Estudio { get; set; }
    }
}
