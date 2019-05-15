using System.Collections.Generic;
using System.Linq;
using Rdio.Mvc.Core.Domain;
using Rdio.Mvc.Core.Repositories;

namespace Rdio.Mvc.Persistence.Repositories
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public RdioContext RdioContext
        {
            get { return Context as RdioContext; }
        }

        public GeneroRepository(RdioContext context) : base(context)
        {
        }

        public IEnumerable<Genero> GetGenero()
        {
            return RdioContext.Generos.ToList();
        }
        
        public Genero GetGeneroById(int GeneroId)
        {
            return RdioContext.Generos.SingleOrDefault(g => g.Id == GeneroId); // meu metodo customizado
        }
    }
}
