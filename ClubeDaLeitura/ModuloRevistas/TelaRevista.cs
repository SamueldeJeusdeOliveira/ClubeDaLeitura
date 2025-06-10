using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloRevistas;
using ClubeDaLeitura.ModuloCaixas;
using System;
using System.Linq;

namespace ClubeDaLeitura.ModuloRevistas
{
    internal class TelaRevista : TelaBase
    {
        private RepositorioRevista repositorioRevista;
        private RepositorioCaixa repositorioCaixa;

        public TelaRevista(RepositorioRevista repoRevista, RepositorioCaixa repoCaixa) : base("Revista", repoRevista)
        {
            repositorioRevista = repoRevista;
            repositorioCaixa = repoCaixa;
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            var revistas = repositorioRevista.SelecionarTodos();

            if (revistas.Count == 0)
            {
                Console.WriteLine("Nenhuma revista cadastrada.");
                return;
            }

            if (exibirCabecalho)
                ExibirCabecalho();

            Console.WriteLine("ID | Título | Edição | Ano | Caixa");
            Console.WriteLine("---------------------------------------");

            foreach (Revista revista in revistas)
            {
                Console.WriteLine($"{revista.id} | {revista.Titulo} | {revista.NumeroEdicao} | {revista.AnoEdicao} | {revista.Caixa.Etiqueta}");
            }
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Digite o título da revista: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o número da edição: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ano da edição: ");
            int anoEdicao = Convert.ToInt32(Console.ReadLine());

            // Listar caixas para escolher
            var caixas = repositorioCaixa.SelecionarTodos();

            if (caixas.Count == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrada. Cadastre uma caixa antes de cadastrar revistas.");
                return null;
            }

            Console.WriteLine("Caixas disponíveis:");

            foreach (Caixa caixa in caixas)
            {
                Console.WriteLine($"{caixa.id} - {caixa.Etiqueta} ({caixa.Cor})");
            }

            Console.Write("Digite o ID da caixa onde a revista ficará armazenada: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa caixaSelecionada = repositorioCaixa.SelecionarRegistroPorId(idCaixa) as Caixa;

            if (caixaSelecionada == null)
            {
                Console.WriteLine("Caixa inválida!");
                return null;
            }

            return new Revista(titulo, numeroEdicao, anoEdicao, caixaSelecionada);
        }
    }
}
