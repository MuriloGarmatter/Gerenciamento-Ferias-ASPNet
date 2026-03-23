using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GerenciamentoFerias.Models;
using GerenciamentoFerias.Data;


namespace GerenciamentoFerias.Pages.RH
{
    public class IndexModel : PageModel
    {
        public List<SolicitacaoFerias> SolicitacoesAprovadas { get; set; } = new();

        public void OnGet()
        {
            var funcionario = MockDatabase.Funcionarios.First();
            SolicitacoesAprovadas = funcionario.Solicitacoes
                .Where(s => s.Status == StatusSolicitacao.APROVADO)
                .ToList();
        }

        public IActionResult OnPostProcessar(int id)
        {
            var funcionario = MockDatabase.Funcionarios.First();
            var solicitacao = funcionario.Solicitacoes.FirstOrDefault(s => s.Id == id);

            if (solicitacao != null && solicitacao.Status == StatusSolicitacao.APROVADO)
            {
                funcionario.Saldo.DiasDisponiveis -= solicitacao.QuantidadeDias;

                solicitacao.Status = StatusSolicitacao.PROCESSADO;

                var historico = new HistoricoFerias
                {
                    Id = funcionario.Historico.Count + 1,
                    DataInicio = solicitacao.DataInicio,
                    DataFim = solicitacao.DataInicio.AddDays(solicitacao.QuantidadeDias),
                    QuantidadeDias = solicitacao.QuantidadeDias,
                    FuncionarioId = funcionario.Id
                };

                funcionario.Historico.Add(historico);
            }

            return RedirectToPage();
        }
    }
}