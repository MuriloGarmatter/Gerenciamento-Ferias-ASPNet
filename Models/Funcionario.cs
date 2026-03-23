namespace GerenciamentoFerias.Models
{
    public class Funcionario : Usuario
    {
        public string Matricula { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public DateTime DataAdmissao { get; set; }
        public SaldoFerias? Saldo { get; set; }
        public List<SolicitacaoFerias> Solicitacoes { get; set; } = new List<SolicitacaoFerias>();

        public List<HistoricoFerias> Historico { get; set; } = new List<HistoricoFerias>();
    }
}