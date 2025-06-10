using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixas;
using System;
using System.Linq;

namespace ClubeDaLeitura.ModuloCaixas
{
    internal class TelaCaixa : TelaBase
    {
        private RepositorioCaixa repositorioCaixa;

        public TelaCaixa(RepositorioCaixa repositorio) : base("Caixa", repositorio)
        {
            repositorioCaixa = repositorio;
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            var caixas = repositorioCaixa.SelecionarTodos();

            if (caixas.Count == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrada.");
                return;
            }

            if (exibirCabecalho)
                ExibirCabecalho();

            Console.WriteLine("ID | Etiqueta | Cor | Dias de Empréstimo");
            Console.WriteLine("------------------------------------------");

            foreach (Caixa caixa in caixas)
            {
                Console.WriteLine($"{caixa.id} | {caixa.Etiqueta} | {caixa.Cor} | {caixa.DiasEmprestimo}");
            }
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a quantidade de dias para empréstimo: ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

            return new Caixa(etiqueta, cor, diasEmprestimo);
        }
    }
}
