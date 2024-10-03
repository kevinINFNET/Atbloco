using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vavazin.Data; // Namespace para seu DbContext
using Vavazin.Models; // Namespace correto da sua classe Anuncio
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Vavazin.Pages
{
    [Authorize]
    public class CreateAnuncioModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateAnuncioModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Anuncio Anuncio { get; set; } 

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Anuncios.Add(Anuncio); 
            await _context.SaveChangesAsync();

            return RedirectToPage("./ValorantPage"); 
        }
    }
}
