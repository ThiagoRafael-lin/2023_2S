namespace senai.inlock.webApi.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get;  set; }
        public string? Nome { get;  set; }

        public List<EstudioDomain> listaEstudios { get; set; }  


    } 
}
