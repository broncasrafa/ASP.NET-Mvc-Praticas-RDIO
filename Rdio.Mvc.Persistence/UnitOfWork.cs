using Rdio.Mvc.Core;
using Rdio.Mvc.Core.Repositories;
using Rdio.Mvc.Persistence.Repositories;

namespace Rdio.Mvc.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RdioContext _context;

        public IMusicRepository Musics { get; private set; }
        public IGeneroRepository Generos { get; private set; }
        public IArtistaRepository Artistas { get; set; }
        public IAlbumRepository Albums { get; set; }

        public UnitOfWork(RdioContext context)
        {
            _context = context;
            Musics = new MusicRepository(_context);
            Generos = new GeneroRepository(_context);
            Artistas = new ArtistaRepository(_context);
            Albums = new AlbumRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
