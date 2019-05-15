using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rdio.Mvc.Core.Domain;

namespace Rdio.Mvc.Core.Repositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        IEnumerable<Album> GetAllAlbums();
        IEnumerable<Album> GetAllMusicsAlbum();
        Album GetAlbumById(int id);
        string GetGeneroAlbum(int id);
    }
}
