using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vavazin.Data;
using System.Security.Claims;

namespace Vavazin.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Senha { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == Email && u.Senha == Senha);

            if (user != null)
            {
                // Cria os claims para o usuário
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Autentica o usuário
                await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal);

                return RedirectToPage("ValorantPage");
            }
            else
            {
                Message = "Login falhou. Tente novamente.";
                return Page();
            }
        }
    }
}
