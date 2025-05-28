using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixas
{
    internal class Caixa
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasDeEmprestimo { get; set; }

        public void Validar() { }
        public void AdicionarRevista() { }
        public void RemoverRevista() { }
    }
}
