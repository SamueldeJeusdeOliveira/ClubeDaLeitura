using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura;

public class Program
{
    public static void Main(string[] args)
    {
        
        TelaPrincipal telaPrincipal = new TelaPrincipal();
        try
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                telaPrincipal.ApresentarMenuPrincipal();

                TelaBase telaEscolhida = telaPrincipal.ObterTela();

                if (telaEscolhida == null)
                    break;

                char opcaoEscolhida = telaEscolhida.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaEscolhida.CadastrarRegistro();
                        break;

                    case '2':
                        telaEscolhida.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaEscolhida.EditarRegistro();
                        break;

                    case '4':
                        telaEscolhida.ExcluirRegistro();
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ocorreu um erro inesperado:");
            Console.WriteLine(ex.Message);

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para reiniciar o sistema ou ESC para encerrar.");

            var tecla = Console.ReadKey(true).Key;

            if (tecla == ConsoleKey.Escape)
            {
                Console.WriteLine("Encerrando o sistema...");
                return;
            }

            Console.Clear();
            Main(args);
        }
    }
}