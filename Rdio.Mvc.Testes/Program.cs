using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rdio.Mvc.Core;
using Rdio.Mvc.Persistence;

namespace Rdio.Mvc.Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            Teste_GetAll();
        }

        private static void Teste_GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new RdioContext()))
            {
                int count = unitOfWork.Musics.GetAll().Count();

                Console.Write("Total de musicas: {0}\n\n\n\n", count.ToString());
                Console.Write("Press any key to exit...");
                Console.Read();
            }
        }        
    }
}
