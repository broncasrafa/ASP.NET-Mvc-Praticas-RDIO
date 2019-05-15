using System.Data.Entity.ModelConfiguration;
using Rdio.Mvc.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rdio.Mvc.Persistence.EntityConfigurations
{
    public class GeneroConfiguration : EntityTypeConfiguration<Genero>
    {
        public GeneroConfiguration()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Descricao).IsRequired().HasMaxLength(100);

            this.ToTable("Genero");
            this.Property(c => c.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Descricao).HasColumnName("Genero");
        }
    }
}
