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
            throw new NotImplementedException();
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
