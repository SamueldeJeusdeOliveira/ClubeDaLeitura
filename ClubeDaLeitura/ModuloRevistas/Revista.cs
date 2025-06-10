using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixas;

namespace ClubeDaLeitura.ModuloRevistas
{
    internal class Revista : EntidadeBase
    {
        public enum SituacaoEmprestimo
        {
            Aberto,
            Fechado
        }

        public class Emprestimo : EntidadeBase
        {
            public Amigo Amigo { get; set; }
            public Revista Revista { get; set; }
            public DateTime DataEmprestimo { get; private set; }
            public DateTime? DataDevolucao { get; private set; }
            public SituacaoEmprestimo Situacao { get; private set; } = SituacaoEmprestimo.Aberto;

            public Emprestimo(Amigo amigo, Revista revista)
            {
                Amigo = amigo;
                Revista = revista;
                DataEmprestimo = DateTime.Now;
            }

            public DateTime ObterDataDevolucao()
            {
                return DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
            }

            public string Validar()
            {
                string resultadoValidacao = "";

                if (Amigo == null)
                    resultadoValidacao += "Amigo não pode ser nulo.\n";

                if (Revista == null)
                    resultadoValidacao += "Revista não pode ser nula.\n";

                if (Revista.Status == StatusRevista.Emprestada)
                    resultadoValidacao += "Revista já está emprestada.\n";

                return resultadoValidacao;
            }

            public void RegistrarDevolucao()
            {
                DataDevolucao = DateTime.Now;
                Situacao = SituacaoEmprestimo.Fechado;
            }

            public override string ToString()
            {
                return $"ID {id} - Amigo: {Amigo.Nome}, Revista: {Revista.Titulo}, Data Empréstimo: {DataEmprestimo.ToShortDateString()}, Situação: {Situacao}";
            }
        }
    }
}
