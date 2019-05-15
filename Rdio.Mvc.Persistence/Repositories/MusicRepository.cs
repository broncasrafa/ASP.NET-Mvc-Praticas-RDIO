using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Rdio.Mvc.Core.Domain;
using Rdio.Mvc.Core.Repositories;

namespace Rdio.Mvc.Persistence.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public RdioContext RdioContext
        {
            get { return Context as RdioContext; }
        }

        public MusicRepository(RdioContext context) : base(context)
        {
        }

        public IEnumerable<Music> GetMusicsByGenero(int GeneroId)
        {
            return RdioContext.Musics.Include(m => m.Genero).Where(m => m.Genero.Id == GeneroId).ToList();
        }

        public IEnumerable<Music> GetMusicsByGeneroAndRating(int GeneroId, int rating)
        {
            return RdioContext.Musics.Include(m => m.Genero).Where(m => m.Genero.Id == GeneroId && m.Rating == rating).ToList();
        }
        
        public IEnumerable<Music> GetMusicsByRating(int rating)
        {
            return RdioContext.Musics.Include(m => m.Genero).Where(m => m.Rating == rating).ToList();
        }

        public IEnumerable<Music> GetTopRatingMusics()
        {
            return RdioContext.Musics.Include(m => m.Genero).Where(m => m.Rating == 5).ToList();
        }

        public IEnumerable<Music> GetAllMusicsWithGeneros()
        {
            return RdioContext.Musics.Include(m => m.Genero).Include(c => c.Artista).Include(c => c.AlbumCollection).ToList();
        }

        public IEnumerable<Music> GetAllFavorites()
        {
            var favorites = RdioContext.Musics.ToList();

            favorites = favorites.Where(c => c.Isfavorite == true).ToList();

            return favorites;
        }

        public IEnumerable<Music> GetAllCincoEstrelas()
        {
            return RdioContext.Musics.Include(m => m.Genero).Where(m => m.Rating == 5).ToList();
        }

        public IEnumerable<Music> GetMusicsByAlbum(int albumId)
        {
            return RdioContext.Musics.Include(c => c.AlbumCollection).Include(c => c.Genero).Include(c => c.Artista).Where(c => c.AlbumCollection.Id == albumId).ToList();
        }

        public Music GetMusic(int id)
        {
            return RdioContext.Musics
                              .Include(c => c.AlbumCollection)
                              .Include(c => c.Artista)
                              .Include(c => c.Genero)
                              .SingleOrDefault(c => c.Id == id);
        }
    }
}
