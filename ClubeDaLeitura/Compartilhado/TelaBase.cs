using System;

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
            Console.WriteLine($"|  1 - Cadastrar {nomeEntidade}   |   2 - Visualizar {nomeEntidade}s    |   3 - Editar {nomeEntidade}    |   4 - Excluir {nomeEntidade}       ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\n                                              Pressione 'Esc' para sair                                                                           ");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            ConsoleKeyInfo tecla = Console.ReadKey();
            Console.WriteLine();

            return tecla.KeyChar;
        }

        public void CadastrarRegistro()
        {
            ExibirCabecalho();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"                                                Cadastro de {nomeEntidade}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine();

            EntidadeBase novoRegistro = ObterDados();

            if (novoRegistro == null)
                return;

            string erros = novoRegistro.Validar();

            if (!string.IsNullOrEmpty(erros))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nErros encontrados:\n" + erros);
                Console.ResetColor();

                Console.Write("\nPressione ENTER para tentar novamente...");
                Console.ReadLine();

                CadastrarRegistro();

                return;
            }

            repositorio.CadastrarRegistro(novoRegistro);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ResetColor();

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        public void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Edição de {nomeEntidade}");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write($"\nDigite o id do {nomeEntidade} que deseja editar: ");
            if (!int.TryParse(Console.ReadLine(), out int idSelecionado))
            {
                Console.WriteLine("ID inválido.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            EntidadeBase registroAtualizado = ObterDados();

            if (registroAtualizado == null)
                return;

            repositorio.EditarRegistro(idSelecionado, registroAtualizado);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{nomeEntidade} editado com sucesso!");
            Console.ResetColor();

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        public void ExcluirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Exclusão de {nomeEntidade}");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write($"\nDigite o id do {nomeEntidade} que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int idSelecionado))
            {
                Console.WriteLine("ID inválido.");
                Console.ReadLine();
                return;
            }

            repositorio.ExcluirRegistro(idSelecionado);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{nomeEntidade} excluído com sucesso!");
            Console.ResetColor();

            Console.WriteLine("\nPressione ENTER para continuar...");
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
