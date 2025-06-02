using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (exibirCabecalho == true)
                ExibirCabecalho();
            Console.WriteLine("Visualização de Revistas");

            Console.WriteLine();

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
               "Id", "Nome", "Responsavel", "Telefone"
            ); 

            EntidadeBase[] revista = repositorioRevista.SelecionarRegistros();

            for (int i = 0; i < revista.Length; i++)
            {
                if (revista[i] == null)
                    continue;

                Revista a = (Revista)revista[i];

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                    a.id, a.Titulo, a.NumEdicaoDoAnoDePublicacao, a.StatusDeEmprestimoECaixa
                );
            }
            Console.ReadLine();
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Qual o título da Revista? ");
            string titulo = Console.ReadLine();
            Console.Write("Qual o Número da edicao do ano de publicação desta revista? ");
            int numPubli = int.Parse(Console.ReadLine());
            Console.Write("Qual o status deste Empréstimo? ");
            string status = Console.ReadLine();

            Revista revista = new Revista(titulo, numPubli, status);
            return revista;
        }
    }
}
