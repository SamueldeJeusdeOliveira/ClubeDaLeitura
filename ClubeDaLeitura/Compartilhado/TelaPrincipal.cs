using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloEmprestimos;
using ClubeDaLeitura.ModuloRevistas;
using System.Media;

namespace ClubeDaLeitura.Compartilhado
{
    public class TelaPrincipal
    {
        private char opcaoEscolhida;

        private RepositorioAmigo repositorioAmigo;
        private RepositorioCaixa repositorioCaixa;
        private RepositorioEmprestimo repositorioEmprestimo;
        private RepositorioRevista repositorioRevista;

        private TelaAmigo telaAmigo;
        private TelaCaixa telaCaixa;
        private TelaEmprestimo telaEmprestimo;
        private TelaRevista telaRevista;

        public TelaPrincipal()
        {
            repositorioAmigo = new RepositorioAmigo();
            repositorioCaixa = new RepositorioCaixa();
            repositorioEmprestimo = new RepositorioEmprestimo();
            repositorioRevista = new RepositorioRevista();

            telaAmigo = new TelaAmigo(repositorioAmigo);
            telaCaixa = new TelaCaixa("Caixa", repositorioCaixa);
            telaEmprestimo = new TelaEmprestimo("Empréstimo", repositorioEmprestimo);
            telaRevista = new TelaRevista("Revista", repositorioRevista);
        }

        public void ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("                            .-. .-')   ('-.         _ .-') _                                          (`-.  _  .-')              \r\n                            \\  ( OO )_(  OO)       ( (  OO) )                                       _(OO  )( \\( -O )             \r\n   .-----.,--.    ,--. ,--.  ;-----.(,------.       \\     .'_ .-'),-----.        ,--.     ,-.-'),--(_/   ,. ,------. .-'),-----. \r\n  '  .--./|  |.-')|  | |  |  | .-.  ||  .---'       ,`'--..._( OO'  .-.  '       |  |.-') |  |OO\\   \\   /(__|   /`. ( OO'  .-.  '\r\n  |  |('-.|  | OO |  | | .-')| '-' /_|  |           |  |  \\  /   |  | |  |       |  | OO )|  |  \\\\   \\ /   /|  /  | /   |  | |  |\r\n /_) |OO  |  |`-' |  |_|( OO | .-. `(|  '--.        |  |   ' \\_) |  |\\|  |       |  |`-' ||  |(_/ \\   '   /,|  |_.' \\_) |  |\\|  |\r\n ||  |`-'(|  '---.|  | | `-' | |  \\  |  .--'        |  |   / : \\ |  | |  |      (|  '---.,|  |_.'  \\     /__|  .  '.' \\ |  | |  |\r\n(_'  '--'\\|      ('  '-'(_.-'| '--'  |  `---.       |  '--'  /  `'  '-'  '       |      (_|  |      \\   /   |  |\\  \\   `'  '-'  '\r\n   `-----'`------' `-----'   `------'`------'       `-------'     `-----'        `------' `--'       `-'    `--' '--'    `-----' ");

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|  1 - Controle de Amigos    |   2 - Controle de Revistas     |    3 - Controle de Emprestimos    |        4 - Controle de Caixa        |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n                                              Pressionar a tecla 'Esc' para sair                                                                           ");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            ConsoleKeyInfo tecla = Console.ReadKey();
            opcaoEscolhida = tecla.KeyChar;
        }

        public TelaBase ObterTela()
        {
            if (opcaoEscolhida == '1')
                return telaAmigo;

            else if (opcaoEscolhida == '2')
                return telaRevista;

            else if (opcaoEscolhida == '3')
                return telaEmprestimo;

            else if (opcaoEscolhida == '4')
                return telaCaixa;

            return null;
        }
    }
}

