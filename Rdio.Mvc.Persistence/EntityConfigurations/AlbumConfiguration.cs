using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rdio.Mvc.Core.Domain;

namespace Rdio.Mvc.Persistence.EntityConfigurations
{
    public class AlbumConfiguration : EntityTypeConfiguration<Album>
    {
        public AlbumConfiguration()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired().IsMaxLength();
            this.Property(c => c.PhotoAlbum).IsMaxLength();
            this.Property(c => c.PhotoAlbumType).HasMaxLength(20);

            this.ToTable("Album");
            this.Property(c => c.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).HasColumnName("Album");
            this.Property(c => c.PhotoAlbum).HasColumnName("PhotoAlbum");
            this.Property(c => c.PhotoAlbumType).HasColumnName("PhotoAlbumType");

            HasRequired(c => c.Artista)
                .WithMany(c => c.Albums)
                .Map(m => m.MapKey("ArtistaId"))
                .WillCascadeOnDelete(false);
        }
    }
}
