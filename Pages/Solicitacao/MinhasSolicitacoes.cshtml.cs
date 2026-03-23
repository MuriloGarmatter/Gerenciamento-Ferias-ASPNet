using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GerenciamentoFerias.Models;
using GerenciamentoFerias.Data;

namespace GerenciamentoFerias.Pages.Solicitacao
{
    public class MinhasSolicitacoesModel : PageModel
    {
        public List<SolicitacaoFerias> MinhasSolicitacoes { get; set; } = new();
        public List<HistoricoFerias> MeuHistorico { get; set; } = new();

        public void OnGet()
        {
            var funcionario = MockDatabase.Funcionarios.First();

            MinhasSolicitacoes = funcionario.Solicitacoes
                .OrderByDescending(s => s.DataSolicitacao)
                .ToList();

            MeuHistorico = funcionario.Historico
                .OrderByDescending(h => h.DataInicio)
                .ToList();
        }

        public IActionResult OnPostCancelar(int id)
        {
            var funcionario = MockDatabase.Funcionarios.First();
            var solicitacao = funcionario.Solicitacoes.FirstOrDefault(s => s.Id == id);

            if (solicitacao != null && solicitacao.Status == StatusSolicitacao.PENDENTE)
            {
                solicitacao.Status = StatusSolicitacao.CANCELADO;
            }

            return RedirectToPage();
        }
    }
}