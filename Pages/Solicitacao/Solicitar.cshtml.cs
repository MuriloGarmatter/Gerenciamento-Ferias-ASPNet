using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GerenciamentoFerias.Models;
using GerenciamentoFerias.Data;

namespace GerenciamentoFerias.Pages.Solicitacao
{
    public class SolicitarModel : PageModel
    {
        [BindProperty]
        public DateTime DataInicio { get; set; } = DateTime.Today;

        [BindProperty]
        public int QuantidadeDias { get; set; }

        public int SaldoDisponivel { get; set; }
        
        public string? Mensagem { get; set; }

        public void OnGet()
        {
            var funcionario = MockDatabase.Funcionarios.First();
            SaldoDisponivel = funcionario.Saldo.DiasDisponiveis;
        }

        public void OnPost()
        {
            var funcionario = MockDatabase.Funcionarios.First();
            SaldoDisponivel = funcionario.Saldo.DiasDisponiveis;

            if (QuantidadeDias > SaldoDisponivel)
            {
                Mensagem = "Saldo insuficiente.";
                return;
            }

            if (DataInicio < DateTime.Today || QuantidadeDias <= 0)
            {
                Mensagem = "Dados inválidos.";
                return;
            }

            var solicitacao = new SolicitacaoFerias
            {
                Id = MockDatabase.NextSolicitacaoId++,
                DataInicio = DataInicio,
                QuantidadeDias = QuantidadeDias,
                Status = StatusSolicitacao.PENDENTE,
                DataSolicitacao = DateTime.Now
            };

            funcionario.Solicitacoes.Add(solicitacao);

            Mensagem = "Solicitação criada com status Pendente.";
        }
    }
}