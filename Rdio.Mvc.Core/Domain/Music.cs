using System.ComponentModel.DataAnnotations.Schema;

namespace Rdio.Mvc.Core.Domain
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public int GeneroId { get; set; }
        [NotMapped]
        public int ArtistaId { get; set; }
        [NotMapped]
        public int AlbumId { get; set; }

        public int TrackNumber { get; set; }
        public int Rating { get; set; }

        [NotMapped]
        public bool Isfavorite
        {
            get
            {
                return this.Favorite != 0;
            }

            set
            {
                if (value)
                {
                    this.Favorite = 1;
                }
                else
                {
                    this.Favorite = 0;
                }
            }
        }
        public int Favorite { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual Artista Artista { get; set; }
        public virtual Album AlbumCollection { get; set; }
    }
}
