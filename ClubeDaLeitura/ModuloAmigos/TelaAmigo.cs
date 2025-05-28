using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloAmigos
{
    internal class TelaAmigo : TelaBase
    {
        RepositorioAmigo repositorioAmigo;

        public TelaAmigo(string nomeEntidade, RepositorioBase repositorio) : base(nomeEntidade, repositorio)
        {
        }

        public void Inserir() { }
        public void Editar() { }
        public void Excluir() { }
        public void VisualizarTodos() { }
        public void VisualizarEmprestimos() { }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            throw new NotImplementedException();
        }

        protected override EntidadeBase ObterDados()
        {
            throw new NotImplementedException();
        }
    }
}
