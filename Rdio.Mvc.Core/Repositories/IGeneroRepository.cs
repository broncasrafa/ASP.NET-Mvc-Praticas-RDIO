using System.Collections.Generic;
using Rdio.Mvc.Core.Domain;

namespace Rdio.Mvc.Core.Repositories
{
    public interface IGeneroRepository
    {
        IEnumerable<Genero> GetGenero();
        Genero GetGeneroById(int GeneroId);
    }
}
