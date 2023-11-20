using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using webApi_CodeFist_Thiago.Domain;

namespace webApi_CodeFist_Thiago.Contexts
{
    public class InlockContexts : DbContext
    {
        /// <summary>
        /// Definição classe entidades do bando de dados
        /// </summary>
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estudio> Estudios { get; set;}
        public DbSet<Jogo> Jogo { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-2KJISQH\\SENAI; Database=Inlock_games_codeFirst_tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        } 
    }
}
