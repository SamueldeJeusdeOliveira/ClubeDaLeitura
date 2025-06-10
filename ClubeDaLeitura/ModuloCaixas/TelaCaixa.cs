using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixas
{
    internal class TelaCaixa : TelaBase
    {
        private RepositorioCaixa repositorioCaixa;

        public TelaCaixa(string nomeEntidade, RepositorioBase repositorio) : base(nomeEntidade, repositorio)
        {
            repositorioCaixa = (RepositorioCaixa)repositorio;
        }

        public void Inserir()
        {
            Console.Clear();
            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Caixa novaCaixa = (Caixa)ObterDados();

            string resultadoValidacao = novaCaixa.Validar();

            if (resultadoValidacao != "")
            {
                Console.WriteLine("Não foi possível cadastrar a caixa devido aos seguintes erros:");
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                return;
            }

            repositorioCaixa.CadastrarRegistro(novaCaixa);

            Console.WriteLine("Caixa cadastrada com sucesso!");
            Console.ReadLine();
        }
        public void Editar()
        {
            Console.Clear();
            Console.WriteLine($"Editando {nomeEntidade}");

            VisualizarTodos();

            Console.Write("Digite o ID da caixa que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarRegistroPorId(id);

            if (caixaSelecionada == null)
            {
                Console.WriteLine("ID inválido.");
                Console.ReadLine();
                return;
            }

            Caixa caixaAtualizada = (Caixa)ObterDados();

            string resultadoValidacao = caixaAtualizada.Validar();

            if (resultadoValidacao != "")
            {
                Console.WriteLine("Não foi possível atualizar a caixa devido aos seguintes erros:");
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                return;
            }

            repositorioCaixa.EditarRegistro(id, caixaAtualizada);

            Console.WriteLine("Caixa atualizada com sucesso!");
            Console.ReadLine();
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();
            Console.WriteLine("Visualização de Caixas");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30}",
                "Id", "Etiqueta", "Dias de Empréstimo"
            );

            EntidadeBase[] caixa = repositorioCaixa.SelecionarRegistros();

            for (int i = 0; i < caixa.Length; i++)
            {
                if (caixa[i] == null)
                    continue;

                Caixa a = (Caixa)caixa[i];

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30}",
                    a.id, a.Etiqueta, a.DiasDeEmprestimo
                );
            }

            Console.ReadLine();
        }
        public void VisualizarTodos()
        {
            VisualizarRegistros(false);
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Qual a Etiqueta? ");
            string etiqueta = Console.ReadLine();

            Console.Write("Qual a cor da caixa? ");
            string cor = Console.ReadLine();

            Console.Write("Quantos dias de empréstimo? ");
            if (!int.TryParse(Console.ReadLine(), out int diasDeEmprestimo))
            {
                Console.WriteLine("Número inválido para dias de empréstimo.");
                Console.ReadLine();
                return null;
            }

            Caixa caixa = new Caixa(etiqueta, cor, diasDeEmprestimo);
            return caixa;
        }
    }
}
