using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GerenciamentoFerias.Models;
using GerenciamentoFerias.Data;

namespace GerenciamentoFerias.Pages.Gestao
{
    public class IndexModel : PageModel
    {
        public List<SolicitacaoFerias> SolicitacoesPendentes { get; set; } = new();

        public void OnGet()
        {
            var funcionario = MockDatabase.Funcionarios.First();
            SolicitacoesPendentes = funcionario.Solicitacoes
                .Where(s => s.Status == StatusSolicitacao.PENDENTE)
                .ToList();
        }

        public IActionResult OnPostAprovar(int id)
        {
            var funcionario = MockDatabase.Funcionarios.First();
            var solicitacao = funcionario.Solicitacoes.FirstOrDefault(s => s.Id == id);

            if (solicitacao != null)
            {
                solicitacao.Status = StatusSolicitacao.APROVADO;
            }

            return RedirectToPage();
        }

        public IActionResult OnPostNegar(int id, string justificativa)
        {
            var funcionario = MockDatabase.Funcionarios.First();
            var solicitacao = funcionario.Solicitacoes.FirstOrDefault(s => s.Id == id);

            if (solicitacao != null)
            {
                solicitacao.Status = StatusSolicitacao.NEGADO;
                solicitacao.JustificativaNegacao = justificativa;
            }

            return RedirectToPage();
        }
    }
}
