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
            repositorioRevista = (RepositorioRevista)repositorio;
        }

        public void Inserir()
        {
            Console.Clear();
            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Revista novaRevista = (Revista)ObterDados();

            string resultadoValidacao = novaRevista.Validar();

            if (resultadoValidacao != "")
            {
                Console.WriteLine("Não foi possível cadastrar a revista devido aos seguintes erros:");
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                return;
            }

            repositorioRevista.CadastrarRegistro(novaRevista);

            Console.WriteLine("Revista cadastrada com sucesso!");
            Console.ReadLine();
        }
        public void Editar()
        {
            Console.Clear();
            Console.WriteLine($"Editando {nomeEntidade}");

            VisualizarTodos();

            Console.Write("Digite o ID da revista que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarRegistroPorId(id);

            if (revistaSelecionada == null)
            {
                Console.WriteLine("ID inválido. Nenhuma revista encontrada.");
                Console.ReadLine();
                return;
            }

            Revista revistaAtualizada = (Revista)ObterDados();

            string resultadoValidacao = revistaAtualizada.Validar();

            if (resultadoValidacao != "")
            {
                Console.WriteLine("Não foi possível atualizar a revista devido aos seguintes erros:");
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                return;
            }

            repositorioRevista.EditarRegistro(id, revistaAtualizada);

            Console.WriteLine("Revista atualizada com sucesso!");
            Console.ReadLine();
        }
        public void Excluir()
        {
            Console.Clear();
            Console.WriteLine($"Excluindo {nomeEntidade}");

            VisualizarTodos();

            Console.Write("Digite o ID da revista que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarRegistroPorId(id);

            if (revistaSelecionada == null)
            {
                Console.WriteLine("ID inválido. Nenhuma revista encontrada.");
                Console.ReadLine();
                return;
            }

            repositorioRevista.ExcluirRegistro(id);

            Console.WriteLine("Revista excluída com sucesso!");
            Console.ReadLine();
        }
        public void VisualizarTodos()
        {
            VisualizarRegistros(false);
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Revistas");
            Console.WriteLine();

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -20} | {3, -30}",
               "Id", "Título", "Número da edição", "Status"
            );

            EntidadeBase[] revistas = repositorioRevista.SelecionarRegistros();

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                    continue;

                Revista a = (Revista)revistas[i];

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -20} | {3, -30}",
                    a.id, a.Titulo, a.NumEdicaoDoAnoDePublicacao, a.StatusDeEmprestimoECaixa
                );
            }
            Console.WriteLine();
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Qual o título da Revista? ");
            string titulo = Console.ReadLine();

            Console.Write("Qual o Número da edição do ano de publicação desta revista? ");
            int numPubli = int.Parse(Console.ReadLine());

            Console.Write("Qual o status deste Empréstimo? ");
            string status = Console.ReadLine();

            Revista revista = new Revista(titulo, numPubli, status);
            return revista;
        }
    }
}
