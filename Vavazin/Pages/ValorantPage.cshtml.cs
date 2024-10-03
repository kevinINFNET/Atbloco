using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Vavazin.Data;
using Vavazin.Models; 

namespace Vavazin.Pages
{
    [Authorize] 
    public class ValorantPageModel : PageModel
    {
        private readonly AppDbContext _context;

        public ValorantPageModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Anuncio> Anuncios { get; set; }
        public List<Anuncio> Destaques { get; set; } 

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } 

        public async Task OnGetAsync()
        {
     
            if (string.IsNullOrEmpty(SearchTerm))
            {
                Anuncios = await _context.Anuncios.ToListAsync();
            }
            else
            {
                Anuncios = await _context.Anuncios
                    .Where(a => a.Titulo.Contains(SearchTerm) || a.Descricao.Contains(SearchTerm)) 
                    .ToListAsync();
            }

            Destaques = new List<Anuncio>
            {
                new Anuncio
                {
                    Id = 1,
                    Titulo = "Contas Valorant",
                    Descricao = "Vendo contas valorant diamante 3 full acesso",
                    ImagemUrl = "https://as1.ftcdn.net/v2/jpg/08/11/25/66/1000_F_811256627_1phrSUEx8CEohg6WNm9vMxxU06grgvYG.jpg",
                    Avaliacoes = new List<Avaliacao>
                    {
                        new Avaliacao { Id = 1, Nota = 5, Comentario = "Excelente!" },
                        new Avaliacao { Id = 2, Nota = 4, Comentario = "Bom!" },
                        new Avaliacao { Id = 3, Nota = 3, Comentario = "Razoável." },
                        new Avaliacao { Id = 4, Nota = 4, Comentario = "Bom!" },
                        new Avaliacao { Id = 5, Nota = 5, Comentario = "Muito bom!" },
                        new Avaliacao { Id = 6, Nota = 4, Comentario = "Gostei!" },
                        new Avaliacao { Id = 7, Nota = 5, Comentario = "Perfeito!" },
                        new Avaliacao { Id = 8, Nota = 4, Comentario = "Recomendo!" },
                        new Avaliacao { Id = 9, Nota = 5, Comentario = "Top!" },
                        new Avaliacao { Id = 10, Nota = 4, Comentario = "Legal!" }
                    }
                },
                new Anuncio
                {
                    Id = 2,
                    Titulo = "Serviço de Elojob/Duobooster",
                    Descricao = "Upo as divisões da sua conta em até 3 dias úteis.",
                    ImagemUrl = "https://as2.ftcdn.net/v2/jpg/05/29/02/97/1000_F_529029772_SZc2obzUPs35Za55E2jkXO1C500m9T5D.jpg",
                    Avaliacoes = new List<Avaliacao>
                    {
                        new Avaliacao { Id = 1, Nota = 5, Comentario = "Excelente!" },
                        new Avaliacao { Id = 2, Nota = 4, Comentario = "Bom!" },
                        new Avaliacao { Id = 3, Nota = 3, Comentario = "Razoável." },
                        new Avaliacao { Id = 4, Nota = 4, Comentario = "Bom!" },
                    }
                },
                new Anuncio
                {
                    Id = 3,
                    Titulo = "Valorant Points",
                    Descricao = "Vendo VP's para sua conta do valorant em promoção",
                    ImagemUrl = "https://as2.ftcdn.net/v2/jpg/07/06/91/73/1000_F_706917325_TXmoErQjreKOcivDgNAf0ONycYPNX4Vt.jpg",
                    Avaliacoes = new List<Avaliacao>
                    {
                new Avaliacao { Id = 1, Nota = 5, Comentario = "Excelente!" },
                    }
                }
            };
        }
    }
}
