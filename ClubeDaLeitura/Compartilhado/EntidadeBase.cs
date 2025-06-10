using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Compartilhado
{
    public abstract class EntidadeBase
    {
        private static int contador = 0;
        public int id { get; private set; }

        public EntidadeBase()
        {
            id = ++contador;
        }
        public abstract string Validar();

    }
}
