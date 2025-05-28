using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloCaixas
{
    internal class TelaCaixa : TelaBase
    {
        public TelaCaixa(string nomeEntidade, RepositorioBase repositorio) : base(nomeEntidade, repositorio)
        {
        }

        public RepositorioCaixa repositorioCaixa { get; set; }
        public void Inserir() { }
        public void Editar() { }
        public void Excluir() { }
        public void VisualizarTodos() { }

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
