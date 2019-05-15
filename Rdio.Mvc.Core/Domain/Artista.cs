using System.Collections.Generic;

namespace Rdio.Mvc.Core.Domain
{
    public class Artista
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Music> Musics { get; set; }

        public Artista()
        {
            Albums = new HashSet<Album>();
            Musics = new HashSet<Music>();
        }
    }
}
