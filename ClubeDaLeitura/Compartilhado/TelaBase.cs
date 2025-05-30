using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Compartilhado
{
    public abstract class TelaBase
    {
        protected string nomeEntidade;
        protected RepositorioBase repositorio;

        protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
        {
            this.nomeEntidade = nomeEntidade;
            this.repositorio = repositorio;
        }

        public char ApresentarMenu()
        {
            ExibirCabecalho();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|  1 - Cadastro de {nomeEntidade}   |     2 - Visualizar {nomeEntidade}s    |     3 - Editar {nomeEntidade}    |  4 - Excluir {nomeEntidade}        ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\n                                              Pressionar a tecla 'Esc' para sair                                                                           ");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            ConsoleKeyInfo tecla = Console.ReadKey();
            char opcaoEscolhida = tecla.KeyChar;

            return opcaoEscolhida;
        }

        public void CadastrarRegistro()
        {
            ExibirCabecalho();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"                                                Cadastro de {nomeEntidade}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine();

            EntidadeBase novoRegistro = ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                CadastrarRegistro();

                return;
            }

            repositorio.CadastrarRegistro(novoRegistro);

            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ReadLine();
        }

        public void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Edição de {nomeEntidade}");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            EntidadeBase registroAtualizado = ObterDados();

            repositorio.EditarRegistro(idSelecionado, registroAtualizado);

            Console.WriteLine($"\n{nomeEntidade} editado com sucesso!");
            Console.ReadLine();
        }

        public void ExcluirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Exclusão de {nomeEntidade}");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o id do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            repositorio.ExcluirRegistro(idSelecionado);

            Console.WriteLine($"\n{nomeEntidade} excluído com sucesso!");
            Console.ReadLine();
        }

        public abstract void VisualizarRegistros(bool exibirCabecalho);

        protected void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine($"                                                Gestão de {nomeEntidade}s");
            Console.WriteLine();
        }

        protected abstract EntidadeBase ObterDados();
    }
}
