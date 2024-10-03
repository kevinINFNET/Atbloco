using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vavazin.Pages
{
    public class TransacaoFinanceiraModel : PageModel
    {
        public string Mensagem { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var nome = Request.Form["nome"];
            var email = Request.Form["email"];
            var cartao = Request.Form["cartao"];
            var dataVencimento = Request.Form["dataVencimento"];
            var codigoSeguranca = Request.Form["codigoSeguranca"];

            Mensagem = "Pagamento realizado com sucesso!";

            return RedirectToPage("/Sucesso", new { mensagem = Mensagem });
        }
    }
}
