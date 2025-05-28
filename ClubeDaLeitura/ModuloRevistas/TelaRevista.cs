using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixas;

namespace ClubeDaLeitura.ModuloRevistas
{
    internal class TelaRevista : TelaBase
    {
        public RepositorioRevista repositorioRevista;
        public RepositorioCaixa repositorioCaixa;

        public TelaRevista(string nomeEntidade, RepositorioBase repositorio) : base(nomeEntidade, repositorio)
        {
        }

        public void Inserir() { }
        public void Editar() { }
        public void Excluir() { }
        public void VisualizarTodos() { }
        public void VisualizarCaixas() { }

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
