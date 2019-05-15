using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Rdio.Mvc.Core.Domain;
using Rdio.Mvc.Core.Repositories;

namespace Rdio.Mvc.Persistence.Repositories
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public RdioContext RdioContext
        {
            get { return Context as RdioContext; }
        }

        public ArtistaRepository(RdioContext context) : base(context)
        {
        }

        public IEnumerable<Artista> GetAllAlbumsArtista()
        {
            return RdioContext.Artistas.Include(c => c.Albums).ToList();
        }

        public IEnumerable<Artista> GetAllArtistas()
        {
            return RdioContext.Artistas.Include(c => c.Albums).ToList();
        }

        public IEnumerable<Artista> GetAllMusicsArtista()
        {
            return RdioContext.Artistas.Include(c => c.Albums).Include(c => c.Musics).ToList();
        }
    }
}
