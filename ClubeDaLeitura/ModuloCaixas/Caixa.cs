using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloCaixas
{
    internal class Caixa : EntidadeBase
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasDeEmprestimo { get; set; }

        public Caixa(string etiqueta, string cor, int diasDeEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasDeEmprestimo = diasDeEmprestimo;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Caixa caixa = (Caixa)registroAtualizado;
            this.Etiqueta = caixa.Etiqueta;
            this.Cor = caixa.Cor;
            this.DiasDeEmprestimo = caixa.DiasDeEmprestimo;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Etiqueta))
                erros += "Etiqueta é obrigatória!\n";

            if (string.IsNullOrWhiteSpace(Cor))
                erros += "Cor é obrigatória!\n";

            if (DiasDeEmprestimo <= 0)
                erros += "Dias de empréstimo devem ser maiores que zero!\n";

            return erros;
        }
    }
}
