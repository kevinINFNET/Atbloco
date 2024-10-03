using System.Collections.Generic;

namespace Vavazin.Models
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }

        public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>(); 

        public double MediaAvaliacoes => Avaliacoes.Count > 0 ? Avaliacoes.Average(a => a.Nota) : 0; 
    }

    public class Avaliacao
    {
        public int Id { get; set; }
        public int Nota { get; set; } 
        public string Comentario { get; set; }
    }
}
