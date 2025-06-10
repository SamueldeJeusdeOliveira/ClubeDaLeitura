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
        public RepositorioAmigo repositorioAmigo;

        public TelaRevista(string nomeEntidade, RepositorioBase repositorio, RepositorioCaixa repositorioCaixa, RepositorioAmigo repositorioAmigo)
           : base(nomeEntidade, repositorio)
        {
            this.repositorioRevista = (RepositorioRevista)repositorio;
            this.repositorioCaixa = repositorioCaixa;
            this.repositorioAmigo = repositorioAmigo;
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

            Console.WriteLine("Visualização de Revistas\n");

            Console.WriteLine(
               "{0, -5} | {1, -20} | {2, -15} | {3, -20} | {4, -20}",
               "Id", "Título", "Nº Edição", "Status", "Caixa"
            );

            EntidadeBase[] registros = repositorioRevista.SelecionarRegistros();

            foreach (EntidadeBase registro in registros)
            {
                if (registro == null)
                    continue;

                Revista revista = registro as Revista;

                if (revista == null)
                    continue;

                string nomeCaixa = revista.caixa?.Etiqueta ?? "Sem caixa";

                Console.WriteLine(
                   "{0, -5} | {1, -20} | {2, -15} | {3, -20} | {4, -20}",
                   revista.id, revista.Titulo, revista.NumEdicaoDoAnoDePublicacao,
                   revista.StatusDeEmprestimoECaixa, nomeCaixa
                );
            }

            Console.WriteLine();
            Console.ReadLine();
        }
        private void ExibirAmigos()
        {
            EntidadeBase[] amigos = repositorioAmigo.SelecionarRegistros();

            foreach (var registro in amigos)
            {
                if (registro == null) continue;

                Amigo a = (Amigo)registro;
                Console.WriteLine($"{a.id} - {a.Nome}");
            }
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Qual o título da Revista? ");
            string titulo = Console.ReadLine();

            Console.Write("Qual o Número da edição do ano de publicação desta revista? ");
            if (!int.TryParse(Console.ReadLine(), out int numPubli))
            {
                Console.WriteLine("Número inválido.");
                Console.ReadLine();
                return null;
            }

            Console.Write("Qual o status deste Empréstimo? ");
            string status = Console.ReadLine();

            ExibirAmigos();

            Console.Write("Digite o ID da Caixa onde a revista está armazenada: ");
            int idCaixa = int.Parse(Console.ReadLine());

            Caixa caixaSelecionada = repositorioCaixa.SelecionarRegistroPorId(idCaixa) as Caixa;

            if (caixaSelecionada == null)
            {
                Console.WriteLine("Caixa não encontrada!");
                Console.ReadLine();
                return null;
            }

            Revista revista = new Revista(titulo, numPubli, status);
            revista.caixa = caixaSelecionada;

            return revista;
        }
    }
}
