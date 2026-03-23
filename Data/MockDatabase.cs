using GerenciamentoFerias.Models;

namespace GerenciamentoFerias.Data
{
    public static class MockDatabase
    {
        public static List<Funcionario> Funcionarios = new()
        {
            new Funcionario
            {
                Id = 1,
                Nome = "Funcionario",
                Saldo = new SaldoFerias { DiasDisponiveis = 30 }
            }
        };

        public static int NextSolicitacaoId = 1;
    }
}