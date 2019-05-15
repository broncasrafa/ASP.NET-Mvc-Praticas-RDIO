using System.Collections.Generic;
using Rdio.Mvc.Core.Domain;

namespace Rdio.Mvc.Core.Repositories
{
    public interface IArtistaRepository : IRepository<Artista>
    {
        IEnumerable<Artista> GetAllArtistas();
        IEnumerable<Artista> GetAllMusicsArtista();
        IEnumerable<Artista> GetAllAlbumsArtista();
    }
}