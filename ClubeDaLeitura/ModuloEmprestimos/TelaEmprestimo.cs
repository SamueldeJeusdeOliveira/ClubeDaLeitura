using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura.ModuloEmprestimos
{
    internal class TelaEmprestimo : TelaBase
    {
        private RepositorioEmprestimo repositorioEmprestimo;
        private RepositorioAmigo repositorioAmigo;
        private RepositorioRevista repositorioRevista;

        public TelaEmprestimo(string nomeEntidade, RepositorioBase repositorioEmprestimo,
            RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
            : base(nomeEntidade, repositorioEmprestimo)
        {
            this.repositorioEmprestimo = (RepositorioEmprestimo)repositorioEmprestimo;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
        }

        public TelaEmprestimo(string nomeEntidade, RepositorioEmprestimo repositorioEmprestimo,
                      RepositorioAmigo repositorioAmigo,
                      RepositorioRevista repositorioRevista)
    : base(nomeEntidade, repositorioEmprestimo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
        }


        public void Inserir()
        {
            Console.Clear();
            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Emprestimo novoEmprestimo = (Emprestimo)ObterDados();

            string resultadoValidacao = novoEmprestimo.Validar();

            if (resultadoValidacao != "")
            {
                Console.WriteLine("Não foi possível cadastrar o empréstimo devido aos seguintes erros:");
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                return;
            }

            repositorioEmprestimo.CadastrarRegistro(novoEmprestimo);

            Console.WriteLine("Empréstimo cadastrado com sucesso!");
            Console.ReadLine();
        }

        public void RegistrarDevolucao()
        {
            Console.Clear();
            Console.WriteLine($"Registrar devolução de {nomeEntidade}");

            VisualizarTodos();

            Console.Write("Digite o ID do empréstimo que deseja registrar a devolução: ");
            int id = int.Parse(Console.ReadLine());

            Emprestimo emprestimoSelecionado = (Emprestimo)repositorioEmprestimo.SelecionarRegistroPorId(id);

            if (emprestimoSelecionado == null)
            {
                Console.WriteLine("ID inválido.");
                Console.ReadLine();
                return;
            }

            if (emprestimoSelecionado.EstaDevolvido())
            {
                Console.WriteLine("Este empréstimo já foi devolvido.");
                Console.ReadLine();
                return;
            }

            emprestimoSelecionado.RegistrarDevolucao();

            Console.WriteLine("Devolução registrada com sucesso!");
            Console.ReadLine();
        }

        public void VisualizarTodos()
        {
            VisualizarRegistros(false);
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();
            Console.WriteLine("Visualização de Amigos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                "Id", "Amigo", "Data do Empréstimo", "Data de Devolução"
            );

            EntidadeBase[] emprestimo = repositorioEmprestimo.SelecionarRegistros();

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i] == null)
                    continue;

                Emprestimo a = (Emprestimo)emprestimo[i];

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                    a.id, a.Amigo, a.DataEmprestimo, a.DataDevolucao
                );
            }

            Console.ReadLine();
        }


        protected override EntidadeBase ObterDados()
        {
            Console.WriteLine("Selecione um amigo pelo ID:");
            ExibirAmigos();
            Console.Write("ID do amigo: ");
            int idAmigo = int.Parse(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarRegistroPorId(idAmigo);

            if (amigoSelecionado == null)
            {
                Console.WriteLine("Amigo não encontrado.");
                return null;
            }

            Console.WriteLine("Selecione uma revista pelo ID:");
            ExibirRevistas();
            Console.Write("ID da revista: ");
            int idRevista = int.Parse(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarRegistroPorId(idRevista);

            if (revistaSelecionada == null)
            {
                Console.WriteLine("Revista não encontrada.");
                return null;
            }

            return new Emprestimo(amigoSelecionado, revistaSelecionada);
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

        private void ExibirRevistas()
        {
            EntidadeBase[] revistas = repositorioRevista.SelecionarRegistros();

            foreach (var registro in revistas)
            {
                if (registro == null) continue;

                Revista r = (Revista)registro;
                Console.WriteLine($"{r.id} - {r.Titulo}");
            }
        }
    }
}
