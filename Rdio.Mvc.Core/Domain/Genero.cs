using System.Collections.Generic;

namespace Rdio.Mvc.Core.Domain
{
    public class Genero
    {
        public Genero()
        {
            Musicas = new List<Music>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        // Uma musica deve ter obrigatóriamente um genero e um genero pode ter um ou mais musicas
        public virtual ICollection<Music> Musicas { get; set; }
    }

    public enum TipoGenero
    {
        RapHipHop = 1,
        Rock = 2,
        Pop = 3,
        Pagode = 4,
        Religious = 5,
        Instrumentals = 6,
        SoundtrackMovies = 7
    }
}
