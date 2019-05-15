using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rdio.Mvc.Core.Domain;

namespace Rdio.Mvc.Persistence.EntityConfigurations
{
    public class ArtistaConfiguration : EntityTypeConfiguration<Artista>
    {
        public ArtistaConfiguration()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Name).HasMaxLength(100);

            this.ToTable("Artista");
            this.Property(c => c.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).HasColumnName("Artista");
                        
        }
    }
}
