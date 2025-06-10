using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Compartilhado
{
    public abstract class RepositorioBase
    {
        protected ArrayList registros = new ArrayList();

        public virtual void CadastrarRegistro(object registro)
        {
            registros.Add(registro);
        }

        public virtual ArrayList SelecionarTodos()
        {
            return registros;
        }

        public virtual object SelecionarRegistroPorId(int id)
        {
            foreach (var item in registros)
            {
                if (((dynamic)item).id == id)
                    return item;
            }
            return null;
        }

        public virtual void ExcluirRegistro(int id)
        {
            object registro = SelecionarRegistroPorId(id);
            if (registro != null)
                registros.Remove(registro);
        }
    }
}
