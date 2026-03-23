using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFerias.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Gestor> Gestores { get; set; }
        public DbSet<SolicitacaoFerias> Solicitacoes { get; set; }
        public DbSet<SaldoFerias> Saldos { get; set; }
        public DbSet<RH> RecursosHumanos { get; set; }
        public DbSet<HistoricoFerias> Historicos { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
    }
}
