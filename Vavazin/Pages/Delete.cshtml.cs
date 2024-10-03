using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vavazin.Data;
using Vavazin.Models;
using System.Threading.Tasks;

namespace Vavazin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Anuncio Anuncio { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Anuncio = await _context.Anuncios.FirstOrDefaultAsync(m => m.Id == id);

            if (Anuncio == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Anuncio == null)
            {
                return NotFound();
            }

            var anuncioToDelete = await _context.Anuncios.FindAsync(Anuncio.Id);
            if (anuncioToDelete != null)
            {
                _context.Anuncios.Remove(anuncioToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ValorantPage");
        }
    }
}
