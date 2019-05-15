using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Rdio.Mvc.Core.Domain;
using Rdio.Mvc.Persistence.EntityConfigurations;

namespace Rdio.Mvc.Persistence
{
    public class RdioContext : DbContext
    {
        public RdioContext() : base("RdioConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Music> Musics { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Artista> Artistas { get; set; }
        public virtual DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new MusicConfiguration());
            modelBuilder.Configurations.Add(new GeneroConfiguration());
            modelBuilder.Configurations.Add(new AlbumConfiguration());
            modelBuilder.Configurations.Add(new ArtistaConfiguration());
        }
    }
}
