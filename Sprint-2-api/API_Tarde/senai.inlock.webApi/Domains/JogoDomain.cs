namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int  IdEstudio { get; set; }

        public string Descricao { get; set; }

        public string DataLancamento { get; set; }

        public string Valor { get; set; }

        public string? Nome { get; set; }
        public EstudioDomain Estudio { get;  set; }

    }
}
