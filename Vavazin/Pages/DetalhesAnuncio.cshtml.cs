using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vavazin.Data;
using Vavazin.Models;

namespace Vavazin.Pages
{
    public class DetalhesAnuncioModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetalhesAnuncioModel(AppDbContext context)
        {
            _context = context;
        }

        public Anuncio Anuncio { get; set; } 

        public async Task OnGetAsync(int id)
        {
            Anuncio = await _context.Anuncios.FindAsync(id); 
            if (Anuncio == null)
            {      
                RedirectToPage("/Error");
            }
        }
    }
}