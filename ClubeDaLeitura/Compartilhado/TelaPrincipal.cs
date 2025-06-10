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
        private TelaAmigo telaAmigo;
        private TelaCaixa telaCaixa;
        private TelaRevista telaRevista;
        private TelaEmprestimo telaEmprestimo;

        public TelaPrincipal()
        {
            // Instanciar os repositórios
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

            // Instanciar as telas, passando os repositórios conforme necessário
            telaAmigo = new TelaAmigo(repositorioAmigo, repositorioEmprestimo);
            telaCaixa = new TelaCaixa(repositorioCaixa, repositorioRevista);
            telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
            telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);
        }

        public void ApresentarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== Clube da Leitura ===");
            Console.WriteLine("1 - Módulo Amigos");
            Console.WriteLine("2 - Módulo Caixas");
            Console.WriteLine("3 - Módulo Revistas");
            Console.WriteLine("4 - Módulo Empréstimos");
            Console.WriteLine("S - Sair");
            Console.Write("Escolha uma opção: ");
        }

        public TelaBase ObterTela()
        {
            char opcao = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            switch (opcao)
            {
                case '1':
                    return telaAmigo;
                case '2':
                    return telaCaixa;
                case '3':
                    return telaRevista;
                case '4':
                    return telaEmprestimo;
                case 'S':
                    return null;
                default:
                    Console.WriteLine("Opção inválida. Pressione Enter para tentar novamente.");
                    Console.ReadLine();
                    return ObterTela();
            }
        }
    }
}

