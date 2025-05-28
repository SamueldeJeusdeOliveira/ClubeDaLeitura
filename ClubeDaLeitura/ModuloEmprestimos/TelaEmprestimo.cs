using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura.ModuloEmprestimos
{
    internal class TelaEmprestimo : TelaBase
    {
        RepositorioEmprestimo repositorioEmprestimo;
        RepositorioAmigo repositorioAmigo;
        RepositorioRevista repositorioRevista;

        public TelaEmprestimo(string nomeEntidade, RepositorioBase repositorio) : base(nomeEntidade, repositorio)
        {
        }

        public void Inserir() { }
        public void Editar() { }
        public void Excluir() { }
        public void VisualizarTodos() { }
        public void VisualizarRevistas() { }
        public void VisualizarAmigos() { }
        public void RegistrarDevolucao() { }

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
