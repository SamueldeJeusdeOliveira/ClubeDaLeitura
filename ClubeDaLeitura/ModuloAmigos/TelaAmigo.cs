using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClubeDaLeitura.ModuloRevistas.Revista;

namespace ClubeDaLeitura.ModuloAmigos
{
    internal class TelaAmigo : TelaBase
    {
        private RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioAmigo repo) : base("Amigo", repo)
        {
            repositorioAmigo = repo;
        }

        public override void Inserir()
        {
            Console.WriteLine("Inserindo novo amigo...");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Responsável: ");
            string responsavel = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new Amigo(nome, responsavel, telefone);

            string erros = amigo.Validar();

            if (string.IsNullOrEmpty(erros))
            {
                repositorioAmigo.CadastrarRegistro(amigo);
                Console.WriteLine("Amigo cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro(s) na validação:");
                Console.WriteLine(erros);
            }
        }

        public override void Editar()
        {
            VisualizarRegistros(true);

            Console.Write("Digite o ID do amigo que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Amigo amigo = repositorioAmigo.SelecionarRegistroPorId(id) as Amigo;

            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado.");
                return;
            }

            Console.Write("Novo nome: ");
            string nome = Console.ReadLine();

            Console.Write("Novo responsável: ");
            string responsavel = Console.ReadLine();

            Console.Write("Novo telefone: ");
            string telefone = Console.ReadLine();

            Amigo amigoAtualizado = new Amigo(nome, responsavel, telefone);

            string erros = amigoAtualizado.Validar();

            if (string.IsNullOrEmpty(erros))
            {
                repositorioAmigo.EditarRegistro(id, amigoAtualizado);
                Console.WriteLine("Amigo atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro(s) na validação:");
                Console.WriteLine(erros);
            }
        }

        public override void Excluir()
        {
            VisualizarRegistros(true);

            Console.Write("Digite o ID do amigo que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Amigo amigo = repositorioAmigo.SelecionarRegistroPorId(id) as Amigo;

            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado.");
                return;
            }

            repositorioAmigo.ExcluirRegistro(id);

            Console.WriteLine("Amigo excluído com sucesso!");
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            var amigos = repositorioAmigo.SelecionarTodos().Cast<Amigo>().ToList();

            if (amigos.Count == 0)
            {
                Console.WriteLine("Nenhum amigo cadastrado.");
                return;
            }

            if (exibirCabecalho)
                ExibirCabecalho();

            Console.WriteLine("Amigos cadastrados:");

            foreach (var amigo in amigos)
            {
                Console.WriteLine($"ID: {amigo.id} | Nome: {amigo.Nome} | Responsável: {amigo.Responsavel} | Telefone: {amigo.Telefone}");
            }
        }
    }
}
