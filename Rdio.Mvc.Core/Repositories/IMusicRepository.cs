using System.Collections.Generic;
using Rdio.Mvc.Core.Domain;

namespace Rdio.Mvc.Core.Repositories
{
    public interface IMusicRepository : IRepository<Music>
    {
        Music GetMusic(int id);        
        IEnumerable<Music> GetMusicsByGenero(int GeneroId);
        IEnumerable<Music> GetMusicsByGeneroAndRating(int GeneroId, int rating);        
        IEnumerable<Music> GetMusicsByRating(int rating);
        IEnumerable<Music> GetTopRatingMusics();
        IEnumerable<Music> GetAllMusicsWithGeneros();        
        IEnumerable<Music> GetAllFavorites();
        IEnumerable<Music> GetAllCincoEstrelas();
        IEnumerable<Music> GetMusicsByAlbum(int albumId);
    }
}
