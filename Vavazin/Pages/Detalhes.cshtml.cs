using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vavazin.Pages
{
    public class DetalhesModel : PageModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public string Preco { get; set; }

        public void OnGet(string titulo, string descricao, string imagemUrl, string preco)
        {
            Titulo = titulo;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            Preco = preco;
        }
    }
}
