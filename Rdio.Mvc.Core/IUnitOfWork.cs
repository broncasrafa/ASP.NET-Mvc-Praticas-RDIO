using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rdio.Mvc.Core.Repositories;

namespace Rdio.Mvc.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IGeneroRepository Generos { get; }
        int Complete();
    }
}
