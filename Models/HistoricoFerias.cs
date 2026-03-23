namespace GerenciamentoFerias.Models
{
    public class HistoricoFerias
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; } 
        public DateTime DataFim { get; set; } 
        public int QuantidadeDias { get; set; } 
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}