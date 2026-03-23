namespace GerenciamentoFerias.Models
{
    public class SolicitacaoFerias
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public int QuantidadeDias { get; set; }
        public StatusSolicitacao Status { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataDecisao { get; set; }
        public string? JustificativaNegacao { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}