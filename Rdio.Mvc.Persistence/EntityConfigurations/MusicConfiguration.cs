using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rdio.Mvc.Core.Domain;

namespace Rdio.Mvc.Persistence.EntityConfigurations
{
    public class MusicConfiguration : EntityTypeConfiguration<Music>
    {
        public MusicConfiguration()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Name).IsRequired().HasMaxLength(1000);
         

            this.ToTable("Musica");
            this.Property(c => c.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).HasColumnName("Musica");
            this.Property(c => c.TrackNumber).HasColumnName("TrackNumber");            
            this.Property(c => c.Favorite).HasColumnName("Favorite");

            HasRequired(c => c.Genero)
                .WithMany(c => c.Musicas)
                .Map(m => m.MapKey("GeneroId"))
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Artista)
                .WithMany(c => c.Musics)
                .Map(m => m.MapKey("ArtistaId"))
                .WillCascadeOnDelete(false);

            HasRequired(c => c.AlbumCollection)
                .WithMany(c => c.Musics)
                .Map(m => m.MapKey("AlbumId"))
                .WillCascadeOnDelete(false);
        }
    }
}
