using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloAmigos
{
    internal class TelaAmigo : TelaBase
    {
        RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioBase repositorio) : base("Amigo", repositorio)
        {
            this.repositorioAmigo = repositorioAmigo;
        }
        public TelaAmigo(RepositorioAmigo repositorioAmigo)
        : base("Amigo", repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }
        
        public void VisualizarEmprestimos(bool exibirCabecalho) 
        {
            if (!exibirCabecalho) { ExibirCabecalho(); }
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();
            Console.WriteLine("Visualização de Amigos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                "Id", "Nome", "Responsavel", "Telefone"
            );

            EntidadeBase[] amigo = repositorioAmigo.SelecionarRegistros();

            for (int i = 0; i < amigo.Length; i++)
            { 
                if (amigo[i] == null)
                    continue;

                Amigo a = (Amigo)amigo[i];

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                    a.id, a.Nome, a.Responsavel, a.Telefone
                );
            }

            Console.ReadLine();
        }

        protected override Amigo ObterDados()
        {
            Console.Write("Qual o nome do amigo? ");
            string nome = Console.ReadLine();
            Console.Write("Qual o nome do Responsável dele? ");
            string responsavel = Console.ReadLine();
            Console.Write("Qual o telefone para contato?(Escreva no formato (xx) xxxx-xxxx) ");
            string telefone = Console.ReadLine();
            Amigo amigos = new Amigo(nome, responsavel, telefone);
            return amigos;
        }
    }
}
