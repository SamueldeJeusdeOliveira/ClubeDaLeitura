using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    internal class Revista
    {
        public string Titulo { get; set; }
        public int NumEdicaoDoAnoDePublicacao { get; set; }
        public string StatusDeEmprestimoECaixa { get; set; }
        public void Validar() { }
        public void Emprestar() { }
        public void Devolver() { }
        public void Reservar() { }
    }
}
