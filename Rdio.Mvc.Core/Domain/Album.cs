using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rdio.Mvc.Core.Domain
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PhotoAlbum { get; set; }
        public string PhotoAlbumType { get; set; }

        [NotMapped]
        public int ArtistaId { get; set; }

        public virtual Artista Artista { get; set; }

        [NotMapped]
        public string GeneroAlbum { get; set; }
              
        public virtual ICollection<Music> Musics { get; set; }

        public Album()
        {
            Musics = new HashSet<Music>();
        }
    }
}
