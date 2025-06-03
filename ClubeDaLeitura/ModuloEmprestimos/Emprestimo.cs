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
    internal class Emprestimo : EntidadeBase
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; } // pode ser null enquanto não devolvido

        public Emprestimo(Amigo amigo, Revista revista)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = null;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Emprestimo emprestimo = (Emprestimo)registroAtualizado;
            this.Amigo = emprestimo.Amigo;
            this.Revista = emprestimo.Revista;
            this.DataEmprestimo = emprestimo.DataEmprestimo;
            this.DataDevolucao = emprestimo.DataDevolucao;
        }

        public override string Validar()
        {
            string erros = "";

            if (Amigo == null)
                erros += "Amigo é obrigatório para o empréstimo.\n";

            if (Revista == null)
                erros += "Revista é obrigatória para o empréstimo.\n";

            if (DataEmprestimo == DateTime.MinValue)
                erros += "Data do empréstimo inválida.\n";

            if (DataDevolucao != null && DataDevolucao < DataEmprestimo)
                erros += "Data de devolução não pode ser anterior à data do empréstimo.\n";

            return erros;
        }

        public bool EstaDevolvido()
        {
            return DataDevolucao != null;
        }

        public void RegistrarDevolucao()
        {
            DataDevolucao = DateTime.Now;
        }
    }
}
