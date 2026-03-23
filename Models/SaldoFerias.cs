namespace GerenciamentoFerias.Models
{
    public class SaldoFerias
    {
        public int Id { get; set; }
        public int DiasDisponiveis { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}
