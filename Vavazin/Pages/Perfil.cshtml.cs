using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Vavazin.Pages
{
    [Authorize]
    public class PerfilModel : PageModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Transacao> HistoricoTransacoes { get; set; }

        public void OnGet()
        {
            Nome = User.Identity.Name;
            Email = User.FindFirst(ClaimTypes.Email)?.Value;

            HistoricoTransacoes = new List<Transacao>
            {
                new Transacao { Produto = "Conta Valorant", Valor = 50.00m, Data = DateTime.Now.AddDays(-10) },
                new Transacao { Produto = "Valorant Points", Valor = 30.00m, Data = DateTime.Now.AddDays(-5) },
                new Transacao { Produto = "Serviço de Elojob", Valor = 100.00m, Data = DateTime.Now.AddDays(-2) }
            };
        }
    }

    public class Transacao
    {
        public string Produto { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
