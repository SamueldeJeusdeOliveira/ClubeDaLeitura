using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloEmprestimos;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Linq;
using static ClubeDaLeitura.ModuloRevistas.Revista;

namespace ClubeDaLeitura.ModuloEmprestimos
{
    internal class TelaEmprestimo : TelaBase
    {
        private RepositorioEmprestimo repositorioEmprestimo;
        private RepositorioAmigo repositorioAmigo;
        private RepositorioRevista repositorioRevista;

        public TelaEmprestimo(RepositorioEmprestimo repoEmprestimo,
            RepositorioAmigo repoAmigo, RepositorioRevista repoRevista)
        {
            repositorioEmprestimo = repoEmprestimo;
            repositorioAmigo = repoAmigo;
            repositorioRevista = repoRevista;
            nomeEntidade = "Empréstimo";
            sufixo = "s";
        }

        public override void Inserir()
        {
            Console.WriteLine("Registrando novo empréstimo...");

            VisualizarAmigos();

            Console.Write("Digite o ID do amigo: ");
            int idAmigo = int.Parse(Console.ReadLine());

            Amigo amigo = repositorioAmigo.SelecionarRegistroPorId(idAmigo) as Amigo;

            if (amigo == null)
            {
                Console.WriteLine("Amigo inválido.");
                return;
            }

            // Verifica se amigo tem empréstimo ativo
            if (repositorioEmprestimo.SelecionarTodos().Cast<Emprestimo>()
                .Any(e => e.Amigo.id == idAmigo && e.Situacao == SituacaoEmprestimo.Aberto))
            {
                Console.WriteLine("Este amigo já possui um empréstimo ativo.");
                return;
            }

            VisualizarRevistas();

            Console.Write("Digite o ID da revista disponível: ");
            int idRevista = int.Parse(Console.ReadLine());

            Revista revista = repositorioRevista.SelecionarRegistroPorId(idRevista) as Revista;

            if (revista == null || revista.Status != StatusRevista.Disponivel)
            {
                Console.WriteLine("Revista inválida ou indisponível.");
                return;
            }

            Emprestimo emprestimo = new Emprestimo(amigo, revista);

            string erros = emprestimo.Validar();

            if (string.IsNullOrEmpty(erros))
            {
                repositorioEmprestimo.CadastrarRegistro(emprestimo);
                revista.Emprestar();

                Console.WriteLine("Empréstimo registrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro(s) ao validar dados:");
                Console.WriteLine(erros);
            }
        }

        public override void Editar()
        {
            // Opcional, geralmente empréstimos não são editados, mas pode implementar caso queira.
            Console.WriteLine("Editar não suportado para empréstimos.");
        }

        public override void Excluir()
        {
            VisualizarTodos();

            Console.Write("Digite o ID do empréstimo que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Emprestimo emprestimo = repositorioEmprestimo.SelecionarRegistroPorId(id) as Emprestimo;

            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo não encontrado.");
                return;
            }

            if (emprestimo.Situacao == SituacaoEmprestimo.Aberto)
            {
                Console.WriteLine("Não é possível excluir um empréstimo aberto.");
                return;
            }

            repositorioEmprestimo.ExcluirRegistro(id);

            Console.WriteLine("Empréstimo excluído com sucesso!");
        }

        public override void VisualizarTodos()
        {
            var emprestimos = repositorioEmprestimo.SelecionarTodos().Cast<Emprestimo>().ToList();

            if (emprestimos.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo registrado.");
                return;
            }

            Console.WriteLine("Empréstimos registrados:");

            foreach (var e in emprestimos)
            {
                Console.WriteLine($"ID: {e.id} | Amigo: {e.Amigo.Nome} | Revista: {e.Revista.Titulo} | Data empréstimo: {e.DataEmprestimo.ToShortDateString()} | Data devolução: {e.ObterDataDevolucao().ToShortDateString()} | Situação: {e.Situacao}");
            }
        }

        public void VisualizarRevistas()
        {
            var revistasDisponiveis = repositorioRevista.SelecionarTodos().Cast<Revista>()
                .Where(r => r.Status == StatusRevista.Disponivel).ToList();

            if (revistasDisponiveis.Count == 0)
            {
                Console.WriteLine("Nenhuma revista disponível para empréstimo.");
                return;
            }

            Console.WriteLine("Revistas disponíveis:");

            foreach (var r in revistasDisponiveis)
            {
                Console.WriteLine($"ID: {r.id} | Título: {r.Titulo} | Edição: {r.NumeroEdicao} | Caixa: {r.Caixa.Etiqueta}");
            }
        }

        public void VisualizarAmigos()
        {
            var amigos = repositorioAmigo.SelecionarTodos().Cast<Amigo>().ToList();

            if (amigos.Count == 0)
            {
                Console.WriteLine("Nenhum amigo cadastrado.");
                return;
            }

            Console.WriteLine("Amigos cadastrados:");

            foreach (var a in amigos)
            {
                Console.WriteLine($"ID: {a.id} | Nome: {a.Nome} | Responsável: {a.Responsavel} | Telefone: {a.Telefone}");
            }
        }

        public void RegistrarDevolucao()
        {
            VisualizarTodos();

            Console.Write("Digite o ID do empréstimo para registrar devolução: ");
            int id = int.Parse(Console.ReadLine());

            Emprestimo emprestimo = repositorioEmprestimo.SelecionarRegistroPorId(id) as Emprestimo;

            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo não encontrado.");
                return;
            }

            if (emprestimo.Situacao != SituacaoEmprestimo.Aberto)
            {
                Console.WriteLine("Empréstimo já está fechado.");
                return;
            }

            emprestimo.RegistrarDevolucao();
            emprestimo.Revista.Devolver();

            Console.WriteLine("Devolução registrada com sucesso!");
        }
    }
}
