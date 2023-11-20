using Microsoft.EntityFrameworkCore;
using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Contexts
{
    public class HealthContext : DbContext
    {

        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Especialidade> Especialidade { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Clinica> Clinica { get; set; }

        public DbSet<Consulta> Consulta { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Comentario> Comentario { get; set; }

        public object Email { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-2KJISQH\\SENAI; initial catalog= webapi.Health-Clinic_Tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;", x => x.UseDateOnlyTimeOnly());
            base.OnConfiguring(optionsBuilder);
        }

    }
}
