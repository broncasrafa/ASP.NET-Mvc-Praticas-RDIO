using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Rdio.Mvc.Core.Domain;
using Rdio.Mvc.Core.Repositories;

namespace Rdio.Mvc.Persistence.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public RdioContext RdioContext
        {
            get { return Context as RdioContext; }
        }

        public AlbumRepository(RdioContext context) : base(context)
        {
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return RdioContext.Albums.Include(c => c.Artista).Include(c => c.Musics).ToList();
        }

        public IEnumerable<Album> GetAllMusicsAlbum()
        {
            return RdioContext.Albums.Include(c => c.Musics).ToList();
        }

        public Album GetAlbumById(int id)
        {
            return RdioContext.Albums.Include(c => c.Artista).Include(c => c.Musics).Where(c => c.Id == id).SingleOrDefault();
        }

        public string GetGeneroAlbum(int id)
        {            
            var album = RdioContext.Albums.Include(c => c.Musics).Where(c => c.Id == id).SingleOrDefault();

            return album.Musics.FirstOrDefault().Genero.Descricao;
        }
    }
}
