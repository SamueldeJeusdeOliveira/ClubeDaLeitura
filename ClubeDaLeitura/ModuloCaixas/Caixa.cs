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
        public void AdicionarRevista() { }
        public void RemoverRevista() { }

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

            

            return erros;
        }
    }
}
