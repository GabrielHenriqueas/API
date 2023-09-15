using Microsoft.EntityFrameworkCore;
using WebApi.InLock_CodeFirst.Domains;

namespace WebApi.InLock_CodeFirst.Contexts
{
    public class InLockContext : DbContext
    {
        /// <summary>
        /// Definição da entidades do banco de dados
        /// </summary>
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE06-S14; Database=inlock_games_codeFirst_tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);

        }
    }
}
