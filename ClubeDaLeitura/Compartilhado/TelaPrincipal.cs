using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloEmprestimos;
using ClubeDaLeitura.ModuloRevistas;

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
        }

        public void ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|             Clube do Livro           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Controle de Amigos");
            Console.WriteLine("2 - Controle de Revistas");
            Console.WriteLine("3 - Controle de Emprestimos");
            Console.WriteLine("4 - Controle de Caixa");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            opcaoEscolhida = Console.ReadLine()[0];
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
