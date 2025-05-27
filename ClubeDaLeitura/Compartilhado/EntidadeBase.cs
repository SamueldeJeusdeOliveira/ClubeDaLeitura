using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int id;

        public abstract void AtualizarRegistro(EntidadeBase registroAtualizado);
        public abstract string Validar();
    }
}
